using System;
using System.Linq;
using Avalonia.Headless.XUnit;
using Avalonia.Logging;

namespace Avalonia.Markup.Declarative.Diagnostics.Tests;

/// <summary>
/// Unit coverage for the helpers behind the canvas-oriented agent tools: screenshot cropping/resampling
/// (which must keep pixel art crisp) and the application log ring buffer.
/// </summary>
public class CanvasToolingDiagnosticsTests
{
    /// <summary>
    /// Builds a checkerboard so a resample can be judged exactly: every pixel is either opaque black or
    /// opaque white, and any blending would show up immediately as a grey pixel.
    /// </summary>
    private static CapturedImage Checkerboard(int width, int height)
    {
        var bgra = new byte[width * height * 4];
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            var i = (y * width + x) * 4;
            var value = (x + y) % 2 == 0 ? (byte)0 : (byte)255;
            bgra[i] = bgra[i + 1] = bgra[i + 2] = value;
            bgra[i + 3] = 255;
        }

        var size = new PixelSize(width, height);
        return new CapturedImage(ControlScreenshotService.EncodePng(bgra, size), bgra, size);
    }

    private static (byte B, byte G, byte R, byte A) PixelAt(CapturedImage image, int x, int y)
    {
        var i = (y * image.Size.Width + x) * 4;
        return (image.Bgra[i], image.Bgra[i + 1], image.Bgra[i + 2], image.Bgra[i + 3]);
    }

    [AvaloniaFact]
    public void Crop_takes_exactly_the_requested_rectangle()
    {
        var source = Checkerboard(8, 8);
        var cropped = ControlScreenshotService.Crop(source, new PixelRect(2, 3, 4, 2));

        Assert.Equal(new PixelSize(4, 2), cropped.Size);
        for (var y = 0; y < 2; y++)
        for (var x = 0; x < 4; x++)
            Assert.Equal(PixelAt(source, x + 2, y + 3), PixelAt(cropped, x, y));
    }

    [AvaloniaFact]
    public void Enlarging_uses_nearest_neighbour_so_pixel_art_stays_crisp()
    {
        var source = Checkerboard(4, 4);
        var enlarged = ControlScreenshotService.Resample(source, new PixelSize(16, 16));

        Assert.Equal(new PixelSize(16, 16), enlarged.Size);

        // Every enlarged pixel must be one of the two source colours — an interpolating resize would
        // produce greys along the checker edges and make a sprite unreadable.
        for (var y = 0; y < 16; y++)
        for (var x = 0; x < 16; x++)
        {
            var (b, g, r, a) = PixelAt(enlarged, x, y);
            Assert.True(b is 0 or 255, $"blended pixel {b} at ({x},{y})");
            Assert.Equal(b, g);
            Assert.Equal(b, r);
            Assert.Equal(255, a);
            Assert.Equal(PixelAt(source, x / 4, y / 4), (b, g, r, a));
        }
    }

    [AvaloniaFact]
    public void Shrinking_averages_so_thin_detail_survives()
    {
        var source = Checkerboard(8, 8);
        var shrunk = ControlScreenshotService.Resample(source, new PixelSize(4, 4));

        Assert.Equal(new PixelSize(4, 4), shrunk.Size);

        // Each target pixel covers a 2x2 checker cell — one black and one white pair — so averaging
        // yields mid grey. Nearest-neighbour would have dropped half the pattern instead.
        for (var y = 0; y < 4; y++)
        for (var x = 0; x < 4; x++)
            Assert.Equal(127, PixelAt(shrunk, x, y).B);
    }

    [Fact]
    public void ResolveTargetSize_scales_then_caps_and_reports_no_change()
    {
        var source = new PixelSize(200, 100);

        Assert.Null(ControlScreenshotService.ResolveTargetSize(source, null, null));
        Assert.Null(ControlScreenshotService.ResolveTargetSize(source, 1, null));
        Assert.Equal(new PixelSize(400, 200), ControlScreenshotService.ResolveTargetSize(source, 2, null));
        Assert.Equal(new PixelSize(100, 50), ControlScreenshotService.ResolveTargetSize(source, null, 100));

        // maxWidth never enlarges, and it is applied after scale so an agent can zoom in yet still cap
        // the payload it gets back.
        Assert.Null(ControlScreenshotService.ResolveTargetSize(source, null, 500));
        Assert.Equal(new PixelSize(300, 150), ControlScreenshotService.ResolveTargetSize(source, 4, 300));
    }

    [Fact]
    public void Log_buffer_filters_by_level_area_and_time()
    {
        AppLogBuffer.Clear();
        try
        {
            AppLogBuffer.Record(LogEventLevel.Information, AppLogOrigin.Console, string.Empty, "loading sprite");
            var cut = DateTimeOffset.Now.AddMilliseconds(1);
            System.Threading.Thread.Sleep(5);
            AppLogBuffer.Record(LogEventLevel.Warning, AppLogOrigin.Avalonia, "Layout", "measure overflow");
            AppLogBuffer.Record(LogEventLevel.Error, AppLogOrigin.ConsoleError, string.Empty, "save failed");

            Assert.Equal(3, AppLogBuffer.Query(null, null, null, 100, out _).Count);

            var warnings = AppLogBuffer.Query(null, LogEventLevel.Warning, null, 100, out _);
            Assert.Equal(2, warnings.Count);
            Assert.DoesNotContain(warnings, e => e.Message.Contains("loading"));

            // The filter matches the Avalonia log area as well as the message.
            var byArea = AppLogBuffer.Query(null, null, "layout", 100, out _);
            Assert.Single(byArea);
            Assert.Equal("measure overflow", byArea[0].Message);

            var recent = AppLogBuffer.Query(cut, null, null, 100, out _);
            Assert.Equal(2, recent.Count);
        }
        finally
        {
            AppLogBuffer.Clear();
        }
    }

    [Fact]
    public void Log_buffer_returns_the_newest_lines_when_the_limit_bites()
    {
        AppLogBuffer.Clear();
        try
        {
            for (var i = 0; i < 10; i++)
                AppLogBuffer.Record(LogEventLevel.Information, AppLogOrigin.Console, string.Empty, $"line {i}");

            var tail = AppLogBuffer.Query(null, null, null, 3, out var matched);

            Assert.Equal(10, matched);
            Assert.Equal(new[] { "line 7", "line 8", "line 9" }, tail.Select(e => e.Message));
        }
        finally
        {
            AppLogBuffer.Clear();
        }
    }

    [Fact]
    public void Log_buffer_drops_the_oldest_lines_and_says_how_many()
    {
        AppLogBuffer.Clear();
        try
        {
            var overflow = AppLogBuffer.Capacity + 25;
            for (var i = 0; i < overflow; i++)
                AppLogBuffer.Record(LogEventLevel.Information, AppLogOrigin.Console, string.Empty, $"line {i}");

            Assert.Equal(25, AppLogBuffer.DroppedCount);

            var all = AppLogBuffer.Query(null, null, null, AppLogBuffer.Capacity, out var matched);
            Assert.Equal(AppLogBuffer.Capacity, matched);
            Assert.Equal("line 25", all[0].Message);
        }
        finally
        {
            AppLogBuffer.Clear();
        }
    }

    [Fact]
    public void Console_capture_forwards_to_the_original_writer_and_records_whole_lines()
    {
        AppLogBuffer.Clear();
        var terminal = new System.IO.StringWriter();
        var realOut = Console.Out;
        Console.SetOut(terminal);

        AppLogSink.Install();
        try
        {
            // Written a fragment at a time, the way Console.Write is normally used — the buffer must
            // record one line, not three shards.
            Console.Write("saving ");
            Console.Write("sprite");
            Console.WriteLine(".png");

            Assert.Equal("saving sprite.png", terminal.ToString().TrimEnd());

            var lines = AppLogBuffer.Query(null, null, "sprite", 10, out _);
            Assert.Single(lines);
            Assert.Equal("saving sprite.png", lines[0].Message);
            Assert.Equal(AppLogOrigin.Console, lines[0].Origin);
        }
        finally
        {
            AppLogSink.Uninstall();
            AppLogBuffer.Clear();
            Console.SetOut(realOut);
        }
    }

    [Fact]
    public void Avalonia_log_sink_chains_onto_the_existing_one()
    {
        AppLogBuffer.Clear();
        var previous = Logger.Sink;
        var spy = new SpyLogSink();
        Logger.Sink = spy;

        AppLogSink.Install(captureConsole: false);
        try
        {
            Logger.TryGet(LogEventLevel.Warning, "Binding")?.Log(this, "binding failed on {Property}", "Text");

            Assert.Contains(spy.Messages, m => m.Contains("binding failed"));

            var recorded = AppLogBuffer.Query(null, null, "binding failed", 10, out _);
            Assert.Single(recorded);
            Assert.Equal("binding failed on Text", recorded[0].Message);
            Assert.Equal("Binding", recorded[0].Area);
        }
        finally
        {
            AppLogSink.Uninstall();
            AppLogBuffer.Clear();
            Logger.Sink = previous;
        }
    }

    private sealed class SpyLogSink : ILogSink
    {
        public System.Collections.Generic.List<string> Messages { get; } = new();

        public bool IsEnabled(LogEventLevel level, string area) => true;

        public void Log(LogEventLevel level, string area, object? source, string messageTemplate) =>
            Messages.Add(messageTemplate);

        public void Log(LogEventLevel level, string area, object? source, string messageTemplate, params object?[] propertyValues) =>
            Messages.Add(messageTemplate);
    }
}
