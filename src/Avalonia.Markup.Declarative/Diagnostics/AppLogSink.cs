using System;
using System.IO;
using System.Text;
using Avalonia.Logging;

namespace Avalonia.Markup.Declarative.Diagnostics;

/// <summary>
/// Feeds <see cref="AppLogBuffer"/> from the two places a running Avalonia app actually writes text:
/// <see cref="Logger.Sink"/> and the console streams.
/// </summary>
/// <remarks>
/// <para>
/// Both hooks are pass-through decorators — the previously configured sink and the original
/// <see cref="Console.Out"/>/<see cref="Console.Error"/> keep receiving everything, so installing this
/// never costs the developer their terminal output. It composes with
/// <see cref="BindingErrorSink"/>: install that first and this wraps it, so binding errors still reach
/// <c>get_errors</c> and also appear in the raw log.
/// </para>
/// <para>
/// Console capture is line-based: characters are accumulated until a newline, because
/// <c>Console.Write</c> is routinely called a fragment at a time and recording fragments would shred
/// every message across several buffer entries.
/// </para>
/// </remarks>
public static class AppLogSink
{
    private static readonly object Gate = new();
    private static BufferingLogSink? _installedSink;
    private static TeeTextWriter? _installedOut;
    private static TeeTextWriter? _installedError;

    /// <summary>Whether the hooks are currently installed.</summary>
    public static bool IsInstalled
    {
        get { lock (Gate) return _installedSink is not null || _installedOut is not null; }
    }

    /// <summary>
    /// Installs the log-buffer hooks (idempotent).
    /// </summary>
    /// <param name="captureConsole">
    /// Whether to also tee <see cref="Console.Out"/>/<see cref="Console.Error"/>. This is the only part
    /// that touches process-global state, so it has its own switch.
    /// </param>
    public static void Install(bool captureConsole = true)
    {
        lock (Gate)
        {
            if (_installedSink is null)
            {
                _installedSink = new BufferingLogSink(Logger.Sink);
                Logger.Sink = _installedSink;
            }

            if (captureConsole && _installedOut is null)
            {
                _installedOut = new TeeTextWriter(Console.Out, LogEventLevel.Information, AppLogOrigin.Console);
                _installedError = new TeeTextWriter(Console.Error, LogEventLevel.Error, AppLogOrigin.ConsoleError);
                Console.SetOut(_installedOut);
                Console.SetError(_installedError);
            }
        }
    }

    /// <summary>Removes the hooks and restores what was there before (idempotent).</summary>
    public static void Uninstall()
    {
        lock (Gate)
        {
            if (_installedSink is not null)
            {
                // Only restore if we are still the active sink; otherwise leave the current one in place.
                if (ReferenceEquals(Logger.Sink, _installedSink))
                    Logger.Sink = _installedSink.Inner;
                _installedSink = null;
            }

            if (_installedOut is not null)
            {
                _installedOut.FlushPending();
                if (ReferenceEquals(Console.Out, _installedOut))
                    Console.SetOut(_installedOut.Inner);
                _installedOut = null;
            }

            if (_installedError is not null)
            {
                _installedError.FlushPending();
                if (ReferenceEquals(Console.Error, _installedError))
                    Console.SetError(_installedError.Inner);
                _installedError = null;
            }
        }
    }

    private sealed class BufferingLogSink : ILogSink
    {
        public BufferingLogSink(ILogSink? inner) => Inner = inner;

        public ILogSink? Inner { get; }

        public bool IsEnabled(LogEventLevel level, string area) =>
            level >= AppLogBuffer.MinimumLevel || (Inner?.IsEnabled(level, area) ?? false);

        public void Log(LogEventLevel level, string area, object? source, string messageTemplate)
        {
            Capture(level, area, messageTemplate, null);
            Inner?.Log(level, area, source!, messageTemplate);
        }

        public void Log(LogEventLevel level, string area, object? source, string messageTemplate, params object?[] propertyValues)
        {
            Capture(level, area, messageTemplate, propertyValues);
            Inner?.Log(level, area, source!, messageTemplate, propertyValues!);
        }

        private static void Capture(LogEventLevel level, string area, string messageTemplate, object?[]? propertyValues)
        {
            if (level < AppLogBuffer.MinimumLevel)
                return;

            AppLogBuffer.Record(level, AppLogOrigin.Avalonia, area, Render(messageTemplate, propertyValues));
        }

        // Avalonia uses positional "{Name}" tokens; substituting them in order is good enough for an
        // agent-readable line and keeps the diagnostics surface free of a structured-logging dependency.
        private static string Render(string template, object?[]? values)
        {
            if (string.IsNullOrEmpty(template) || values is null || values.Length == 0)
                return template ?? string.Empty;

            var builder = new StringBuilder(template.Length + 32);
            var valueIndex = 0;
            for (var i = 0; i < template.Length; i++)
            {
                var c = template[i];
                if (c == '{' && i + 1 < template.Length && template[i + 1] != '{')
                {
                    var end = template.IndexOf('}', i);
                    if (end > i)
                    {
                        builder.Append(valueIndex < values.Length ? values[valueIndex]?.ToString() ?? "null" : string.Empty);
                        valueIndex++;
                        i = end;
                        continue;
                    }
                }

                builder.Append(c);
            }

            return builder.ToString();
        }
    }

    /// <summary>
    /// A <see cref="TextWriter"/> that forwards everything to the original writer and additionally
    /// records completed lines into <see cref="AppLogBuffer"/>.
    /// </summary>
    private sealed class TeeTextWriter : TextWriter
    {
        // A writer that never emits a newline (a progress spinner, say) must not grow the pending
        // buffer without bound; flush it as one line once it gets long.
        private const int MaxPendingChars = 8192;

        private readonly LogEventLevel _level;
        private readonly AppLogOrigin _origin;
        private readonly StringBuilder _pending = new();

        public TeeTextWriter(TextWriter inner, LogEventLevel level, AppLogOrigin origin)
        {
            Inner = inner;
            _level = level;
            _origin = origin;
        }

        public TextWriter Inner { get; }

        public override Encoding Encoding => Inner.Encoding;

        public override IFormatProvider FormatProvider => Inner.FormatProvider;

        public override void Write(char value)
        {
            Inner.Write(value);
            Append(value);
        }

        public override void Write(string? value)
        {
            Inner.Write(value);
            if (value is not null)
                Append(value);
        }

        public override void WriteLine(string? value)
        {
            Inner.WriteLine(value);
            if (value is not null)
                Append(value);
            Append('\n');
        }

        public override void WriteLine()
        {
            Inner.WriteLine();
            Append('\n');
        }

        public override void Flush() => Inner.Flush();

        /// <summary>Records whatever is buffered but not yet newline-terminated.</summary>
        public void FlushPending()
        {
            lock (_pending)
                Emit();
        }

        private void Append(string value)
        {
            lock (_pending)
            {
                foreach (var c in value)
                    AppendCore(c);
            }
        }

        private void Append(char value)
        {
            lock (_pending)
                AppendCore(value);
        }

        private void AppendCore(char value)
        {
            if (value == '\n')
            {
                Emit();
                return;
            }

            if (value != '\r')
                _pending.Append(value);

            if (_pending.Length >= MaxPendingChars)
                Emit();
        }

        private void Emit()
        {
            if (_pending.Length == 0)
                return;

            AppLogBuffer.Record(_level, _origin, string.Empty, _pending.ToString());
            _pending.Clear();
        }
    }
}
