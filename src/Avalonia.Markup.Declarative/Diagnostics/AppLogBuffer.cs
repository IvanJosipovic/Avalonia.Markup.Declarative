using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Logging;

namespace Avalonia.Markup.Declarative.Diagnostics;

/// <summary>
/// Where a buffered log line came from.
/// </summary>
public enum AppLogOrigin
{
    /// <summary>Written through <see cref="Avalonia.Logging.Logger"/> (framework or app).</summary>
    Avalonia,

    /// <summary>Written to <see cref="Console.Out"/>.</summary>
    Console,

    /// <summary>Written to <see cref="Console.Error"/>.</summary>
    ConsoleError
}

/// <summary>
/// One buffered log line.
/// </summary>
/// <param name="Timestamp">When it was recorded.</param>
/// <param name="Level">Severity, mapped onto Avalonia's scale.</param>
/// <param name="Origin">Which stream it arrived on.</param>
/// <param name="Area">Avalonia log area (e.g. <c>Binding</c>, <c>Layout</c>), or empty for console output.</param>
/// <param name="Message">The rendered message.</param>
public sealed record AppLogEntry(
    DateTimeOffset Timestamp,
    LogEventLevel Level,
    AppLogOrigin Origin,
    string Area,
    string Message)
{
    /// <summary>Renders the entry as a single agent-friendly line.</summary>
    public override string ToString()
    {
        var tag = Area.Length > 0 ? $"{Level}/{Area}" : Level.ToString();
        var origin = Origin switch
        {
            AppLogOrigin.Console => "stdout",
            AppLogOrigin.ConsoleError => "stderr",
            _ => "log"
        };
        return string.Format(CultureInfo.InvariantCulture, "[{0:HH:mm:ss.fff}] {1} {2}: {3}", Timestamp, origin, tag, Message);
    }
}

/// <summary>
/// A ring buffer of the application's recent log output, so an agent can read what the app printed
/// without owning its process.
/// </summary>
/// <remarks>
/// This exists because the common working setup is the developer running the app from an IDE (hot
/// reload) while the agent attaches over MCP: there is no stdout for the agent to read. It is
/// deliberately separate from <see cref="DiagnosticsErrorLog"/>, which holds only the curated
/// build/binding/runtime <em>errors</em> that <c>get_errors</c> reports — this buffer is the raw,
/// high-volume stream.
/// </remarks>
public static class AppLogBuffer
{
    /// <summary>How many lines are kept before the oldest are dropped.</summary>
    public const int Capacity = 4000;

    private static readonly object Gate = new();
    private static readonly Queue<AppLogEntry> Entries = new(Capacity);
    private static long _dropped;

    /// <summary>
    /// The lowest level captured from <see cref="Avalonia.Logging.Logger"/>. Console output is always
    /// captured regardless.
    /// </summary>
    /// <remarks>
    /// The default is deliberately <see cref="LogEventLevel.Warning"/> rather than something chattier.
    /// A log sink does not merely observe: <c>Logger.TryGet</c> asks it whether a level/area is enabled
    /// and skips formatting the message when it says no. Lowering this therefore <em>switches on</em>
    /// framework tracing the app was not paying for — Avalonia logs every layout pass at
    /// <see cref="LogEventLevel.Information"/>, which in a render-heavy app both costs time and floods
    /// the buffer, pushing the app's own messages out of it. Lower it deliberately, and put it back.
    /// </remarks>
    public static LogEventLevel MinimumLevel { get; set; } = LogEventLevel.Warning;

    /// <summary>How many lines have been dropped because the buffer was full.</summary>
    public static long DroppedCount
    {
        get { lock (Gate) return _dropped; }
    }

    /// <summary>Appends a line, evicting the oldest when the buffer is full.</summary>
    public static void Record(LogEventLevel level, AppLogOrigin origin, string area, string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        var entry = new AppLogEntry(DateTimeOffset.Now, level, origin, area ?? string.Empty, message);

        lock (Gate)
        {
            Entries.Enqueue(entry);
            while (Entries.Count > Capacity)
            {
                Entries.Dequeue();
                _dropped++;
            }
        }
    }

    /// <summary>
    /// Returns the matching lines, oldest first. When more than <paramref name="limit"/> match, the
    /// <b>most recent</b> ones are returned — a truncated tail is what you want when chasing what just
    /// happened.
    /// </summary>
    /// <param name="since">Only lines at or after this moment.</param>
    /// <param name="minimumLevel">Only lines at or above this severity.</param>
    /// <param name="filter">Only lines whose message or area contains this text (case-insensitive).</param>
    /// <param name="limit">Maximum lines to return.</param>
    /// <param name="totalMatched">How many lines matched before the limit was applied.</param>
    public static IReadOnlyList<AppLogEntry> Query(
        DateTimeOffset? since,
        LogEventLevel? minimumLevel,
        string? filter,
        int limit,
        out int totalMatched)
    {
        limit = Math.Clamp(limit, 1, Capacity);
        var matched = new List<AppLogEntry>();

        lock (Gate)
        {
            foreach (var entry in Entries)
            {
                if (since is { } from && entry.Timestamp < from)
                    continue;
                if (minimumLevel is { } level && entry.Level < level)
                    continue;
                if (!string.IsNullOrEmpty(filter) &&
                    entry.Message.IndexOf(filter, StringComparison.OrdinalIgnoreCase) < 0 &&
                    entry.Area.IndexOf(filter, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                matched.Add(entry);
            }
        }

        totalMatched = matched.Count;
        return matched.Count <= limit ? matched : matched.GetRange(matched.Count - limit, limit);
    }

    /// <summary>Parses a level name (<c>verbose|debug|information|warning|error|fatal</c>).</summary>
    public static bool TryParseLevel(string? text, out LogEventLevel level)
    {
        switch (text?.Trim().ToLowerInvariant())
        {
            case "verbose" or "trace":
                level = LogEventLevel.Verbose;
                return true;
            case "debug":
                level = LogEventLevel.Debug;
                return true;
            case "info" or "information":
                level = LogEventLevel.Information;
                return true;
            case "warn" or "warning":
                level = LogEventLevel.Warning;
                return true;
            case "error":
                level = LogEventLevel.Error;
                return true;
            case "fatal" or "critical":
                level = LogEventLevel.Fatal;
                return true;
            default:
                level = LogEventLevel.Verbose;
                return false;
        }
    }

    /// <summary>Removes all buffered lines (mainly for tests).</summary>
    public static void Clear()
    {
        lock (Gate)
        {
            Entries.Clear();
            _dropped = 0;
        }
    }
}
