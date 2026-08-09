using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Avalonia.Controls;
using Avalonia.Rendering;
using Avalonia.VisualTree;

namespace Avalonia.Markup.Declarative.Diagnostics;

/// <summary>
/// A snapshot of how hard a top-level is working to draw itself.
/// </summary>
/// <param name="Title">Window title (or type name for a single-view top-level).</param>
/// <param name="ClientSize">Client size in DIPs.</param>
/// <param name="FrameSize">Outer frame size in DIPs, when the backend reports one.</param>
/// <param name="RenderScaling">DIP-to-pixel scale factor.</param>
/// <param name="VisualCount">Number of visuals in the tree — the main driver of layout/render cost.</param>
/// <param name="LayoutPasses">Measure/arrange passes in the last timed layout run.</param>
/// <param name="LayoutElapsed">How long that layout run took.</param>
/// <param name="LayoutTimingArmed">Whether Avalonia was actually recording layout timings.</param>
/// <param name="Frames">Frames observed while sampling.</param>
/// <param name="SampleDuration">How long the sample ran.</param>
/// <param name="DebugOverlays">Renderer debug overlays currently enabled.</param>
public sealed record RenderStats(
    string Title,
    Size ClientSize,
    Size? FrameSize,
    double RenderScaling,
    int VisualCount,
    int? LayoutPasses,
    TimeSpan? LayoutElapsed,
    bool LayoutTimingArmed,
    int Frames,
    TimeSpan SampleDuration,
    string DebugOverlays)
{
    /// <summary>Frames per second measured over the sample window, or null if nothing was sampled.</summary>
    public double? Fps =>
        SampleDuration > TimeSpan.Zero ? Frames / SampleDuration.TotalSeconds : null;

    /// <summary>Renders the snapshot as agent-readable lines.</summary>
    public override string ToString()
    {
        var builder = new StringBuilder();
        var c = CultureInfo.InvariantCulture;

        builder.Append("Window: ").Append(Title).Append('\n');
        builder.Append("Client size: ").AppendFormat(c, "{0:0.#}x{1:0.#} DIP", ClientSize.Width, ClientSize.Height);
        builder.AppendFormat(c, " ({0:0.#}x{1:0.#} px at scaling {2:0.##})",
            ClientSize.Width * RenderScaling, ClientSize.Height * RenderScaling, RenderScaling).Append('\n');
        if (FrameSize is { } frame)
            builder.AppendFormat(c, "Frame size: {0:0.#}x{1:0.#} DIP\n", frame.Width, frame.Height);

        builder.Append("Visuals in tree: ").Append(VisualCount.ToString(c)).Append('\n');

        if (!LayoutTimingArmed)
        {
            // Reporting the raw zeroes here would read as "layout is instant" when it actually means
            // "nobody measured it".
            builder.Append("Last layout run: not measured — Avalonia only times layout while the " +
                           "LayoutTimeGraph debug overlay is on. Pass layoutTiming=true to switch it on " +
                           "for the sample (it draws a graph on the window while active).\n");
        }
        else if (LayoutPasses is { } passes && LayoutElapsed is { } elapsed)
        {
            builder.AppendFormat(c, "Last layout run: {0} pass(es) in {1:0.##} ms", passes, elapsed.TotalMilliseconds);
            if (passes == 0)
                builder.Append(" (no layout ran during the sample — the UI is settled)");
            builder.Append('\n');
        }
        else
        {
            builder.Append("Last layout run: not reported by this Avalonia build.\n");
        }

        if (Fps is { } fps)
        {
            builder.AppendFormat(c, "Frames: {0} in {1:0} ms → {2:0.#} fps", Frames, SampleDuration.TotalMilliseconds, fps);
            if (Frames == 0)
                builder.Append(" (the window is idle — nothing requested a redraw during the sample)");
            builder.Append('\n');
        }

        builder.Append("Debug overlays: ").Append(DebugOverlays).Append('\n');
        return builder.ToString();
    }
}

/// <summary>
/// Reads the renderer's own diagnostics for a top-level, and measures frame rate by counting real
/// presented frames.
/// </summary>
/// <remarks>
/// Observational by default: nothing is enabled and no redraw is forced, so sampling a live app cannot
/// itself change what is being measured. The one exception is opt-in — see
/// <see cref="EnableLayoutTiming"/>. Layout timing lives on an internal property of
/// <c>RendererDiagnostics</c>, so it is read by reflection and reported as unavailable rather than
/// throwing if a future Avalonia moves it.
/// </remarks>
public static class RenderStatsInspector
{
    // RendererDiagnostics itself is public; only this property is internal.
    private static readonly PropertyInfo? LastLayoutPassTimingProperty =
        typeof(RendererDiagnostics).GetProperty("LastLayoutPassTiming", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

    /// <summary>
    /// Collects everything that can be read synchronously. <paramref name="frames"/> and
    /// <paramref name="sampleDuration"/> come from a <see cref="FrameCounter"/> the caller ran; pass
    /// zero for a snapshot without a frame-rate measurement.
    /// </summary>
    public static RenderStats Collect(TopLevel top, int frames, TimeSpan sampleDuration)
    {
        ArgumentNullException.ThrowIfNull(top);

        TryGetLayoutTiming(top, out var passes, out var elapsed);

        return new RenderStats(
            Title: (top as Window)?.Title ?? top.GetType().Name,
            ClientSize: top.ClientSize,
            FrameSize: top.FrameSize,
            RenderScaling: top.RenderScaling,
            VisualCount: top.GetSelfAndVisualDescendants().Count(),
            LayoutPasses: passes,
            LayoutElapsed: elapsed,
            LayoutTimingArmed: IsLayoutTimingArmed(top),
            Frames: frames,
            SampleDuration: sampleDuration,
            DebugOverlays: top.RendererDiagnostics.DebugOverlays.ToString());
    }

    /// <summary>
    /// Whether Avalonia is currently recording layout timings for <paramref name="top"/>.
    /// </summary>
    /// <remarks>
    /// Avalonia wires the layout stopwatch only while the <c>LayoutTimeGraph</c> overlay is on; with it
    /// off the timing property keeps whatever it last held (zero, normally), which would otherwise read
    /// as a real "0 ms" measurement.
    /// </remarks>
    public static bool IsLayoutTimingArmed(TopLevel top)
    {
        ArgumentNullException.ThrowIfNull(top);
        return top.RendererDiagnostics.DebugOverlays.HasFlag(RendererDebugOverlays.LayoutTimeGraph);
    }

    /// <summary>
    /// Turns the <c>LayoutTimeGraph</c> overlay on so layout runs are timed, and restores the previous
    /// overlays when the returned scope is disposed.
    /// </summary>
    /// <remarks>
    /// This is the one thing here that changes the app, so it is never done implicitly: the overlay draws
    /// a visible graph on the window, which would contaminate any screenshot taken while it is active.
    /// </remarks>
    public static IDisposable EnableLayoutTiming(TopLevel top)
    {
        ArgumentNullException.ThrowIfNull(top);
        return new LayoutTimingScope(top);
    }

    private sealed class LayoutTimingScope : IDisposable
    {
        private readonly TopLevel _top;
        private readonly RendererDebugOverlays _previous;

        public LayoutTimingScope(TopLevel top)
        {
            _top = top;
            _previous = top.RendererDiagnostics.DebugOverlays;
            top.RendererDiagnostics.DebugOverlays = _previous | RendererDebugOverlays.LayoutTimeGraph;
        }

        public void Dispose() => _top.RendererDiagnostics.DebugOverlays = _previous;
    }

    /// <summary>
    /// Reads the last layout pass count/duration from the renderer diagnostics. Returns false when the
    /// running Avalonia does not expose it.
    /// </summary>
    public static bool TryGetLayoutTiming(TopLevel top, out int? passes, out TimeSpan? elapsed)
    {
        passes = null;
        elapsed = null;

        try
        {
            if (LastLayoutPassTimingProperty?.GetValue(top.RendererDiagnostics) is not { } timing)
                return false;

            var type = timing.GetType();
            if (type.GetProperty("PassCounter")?.GetValue(timing) is int passCounter)
                passes = passCounter;
            if (type.GetProperty("Elapsed")?.GetValue(timing) is TimeSpan value)
                elapsed = value;
        }
        catch (Exception)
        {
            return false;
        }

        return passes is not null && elapsed is not null;
    }

    /// <summary>
    /// Counts frames the top-level actually presents, by re-arming
    /// <see cref="TopLevel.RequestAnimationFrame"/> from its own callback.
    /// </summary>
    /// <remarks>
    /// Requesting an animation frame does not by itself force the renderer to draw anything it wasn't
    /// going to draw, so an idle window correctly counts zero rather than being spun up to 60 fps by the
    /// act of measuring it. Start and dispose on the UI thread.
    /// </remarks>
    public sealed class FrameCounter : IDisposable
    {
        private readonly TopLevel _top;
        private volatile bool _stopped;
        private int _frames;

        private FrameCounter(TopLevel top) => _top = top;

        /// <summary>Frames observed so far.</summary>
        public int Frames => _frames;

        /// <summary>Begins counting on <paramref name="top"/>. Call on the UI thread.</summary>
        public static FrameCounter Start(TopLevel top)
        {
            ArgumentNullException.ThrowIfNull(top);
            var counter = new FrameCounter(top);
            counter.Arm();
            return counter;
        }

        /// <summary>Stops counting.</summary>
        public void Dispose() => _stopped = true;

        private void Arm() => _top.RequestAnimationFrame(_ =>
        {
            if (_stopped)
                return;

            _frames++;
            Arm();
        });
    }
}
