using System;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;

namespace Avalonia.Markup.Declarative.Diagnostics;

/// <summary>
/// How a control screenshot should be produced.
/// </summary>
public enum ScreenshotMode
{
    /// <summary>Render just the control's own subtree.</summary>
    Isolated,

    /// <summary>Render the whole window, then crop to the control's bounds (shows real context).</summary>
    InContext
}

/// <summary>
/// A captured image in both encoded (PNG) and raw (BGRA8888) form. The raw pixels enable pixel
/// comparison without re-decoding.
/// </summary>
/// <param name="Png">PNG-encoded bytes.</param>
/// <param name="Bgra">Raw BGRA8888 pixels, row-major, stride = <c>Size.Width * 4</c>.</param>
/// <param name="Size">Pixel dimensions.</param>
public readonly record struct CapturedImage(byte[] Png, byte[] Bgra, PixelSize Size);

/// <summary>
/// Captures PNG screenshots of controls and top-levels via <see cref="RenderTargetBitmap"/>.
/// </summary>
/// <remarks>
/// <para>
/// Rendering re-draws the visual, so it works even for a minimized or occluded window. All methods
/// must run on the UI thread; the caller is responsible for marshaling.
/// </para>
/// <para>
/// A rendering backend must be present in the running app (it is, in a real desktop app; headless
/// tests need <c>Avalonia.Headless.Skia</c>).
/// </para>
/// </remarks>
public static class ControlScreenshotService
{
    private static readonly Vector StandardDpi = new(96, 96);

    /// <summary>
    /// Captures a control as PNG bytes.
    /// </summary>
    public static byte[] CaptureControlPng(Control control, ScreenshotMode mode = ScreenshotMode.Isolated)
    {
        using var bitmap = RenderControl(control, mode);
        return Encode(bitmap);
    }

    /// <summary>
    /// Captures an entire top-level (window) as PNG bytes.
    /// </summary>
    public static byte[] CaptureTopLevelPng(TopLevel top)
    {
        ArgumentNullException.ThrowIfNull(top);
        using var bitmap = RenderToBitmap(top, ResolveTopLevelSize(top));
        return Encode(bitmap);
    }

    /// <summary>
    /// Captures a control as PNG plus raw pixels (for comparison).
    /// </summary>
    public static CapturedImage CaptureControl(Control control, ScreenshotMode mode = ScreenshotMode.Isolated)
    {
        using var bitmap = RenderControl(control, mode);
        return Capture(bitmap);
    }

    /// <summary>
    /// Captures a top-level as PNG plus raw pixels (for comparison).
    /// </summary>
    public static CapturedImage CaptureTopLevel(TopLevel top)
    {
        ArgumentNullException.ThrowIfNull(top);
        using var bitmap = RenderToBitmap(top, ResolveTopLevelSize(top));
        return Capture(bitmap);
    }

    /// <summary>
    /// Like <see cref="CaptureTopLevel"/>, but first drains queued layout/binding work and, if the
    /// captured frame is degenerate (a single flat color — the classic "captured before the layout
    /// settled" empty/dark frame), forces a layout pass and retries once. Prevents an empty screenshot
    /// right after opening a popup or switching state (P6).
    /// </summary>
    public static CapturedImage CaptureTopLevelStable(TopLevel top)
    {
        ArgumentNullException.ThrowIfNull(top);
        return CaptureStable(top, () => CaptureTopLevel(top));
    }

    /// <summary>
    /// Like <see cref="CaptureControl"/>, but drains queued work and retries once on a degenerate frame
    /// (P6).
    /// </summary>
    public static CapturedImage CaptureControlStable(Control control, ScreenshotMode mode = ScreenshotMode.Isolated)
    {
        ArgumentNullException.ThrowIfNull(control);
        return CaptureStable(control, () => CaptureControl(control, mode));
    }

    private static CapturedImage CaptureStable(Control target, Func<CapturedImage> capture)
    {
        // Settle first: flush layout/binding/render jobs so we don't snapshot a half-arranged frame.
        Dispatcher.UIThread.RunJobs();
        var image = capture();

        if (!IsDegenerate(image.Bgra))
            return image;

        // A flat frame usually means layout hadn't run yet. Force one more measure/arrange + flush and
        // re-capture once; if it is still flat it is genuinely a solid-colored control and we keep it.
        target.InvalidateMeasure();
        target.InvalidateArrange();
        Dispatcher.UIThread.RunJobs();
        return capture();
    }

    /// <summary>
    /// Returns true when the pixel buffer is (near-)uniform — a single flat color — which for a UI
    /// capture almost always means an unrendered / not-yet-laid-out frame rather than real content.
    /// </summary>
    public static bool IsDegenerate(byte[] bgra)
    {
        if (bgra is null || bgra.Length < 8)
            return true;

        var pixelCount = bgra.Length / 4;
        if (pixelCount == 0)
            return true;

        byte b0 = bgra[0], g0 = bgra[1], r0 = bgra[2], a0 = bgra[3];
        var identical = 0L;
        for (var i = 0; i < bgra.Length; i += 4)
        {
            if (bgra[i] == b0 && bgra[i + 1] == g0 && bgra[i + 2] == r0 && bgra[i + 3] == a0)
                identical++;
        }

        // >= 99.9% of pixels are the exact same color ⇒ treat as degenerate.
        return identical >= pixelCount * 0.999;
    }

    /// <summary>
    /// Captures a rectangular <paramref name="region"/> of a top-level, in the same absolute client-DIP
    /// coordinates as hit-testing and the pointer tools (at 96 DPI one DIP is one captured pixel).
    /// </summary>
    /// <remarks>
    /// The whole top-level is rendered and the region is then cut out of the pixel buffer. Cropping
    /// rather than rendering a sub-visual is what makes an arbitrary rectangle — a slice of a custom
    /// canvas that is not a control at all — capturable, and it keeps overlapping content (popups,
    /// adorners) in the shot. The region is clamped to the window; a rectangle entirely outside it is
    /// an error rather than a blank image.
    /// </remarks>
    public static CapturedImage CaptureRegionStable(TopLevel top, Rect region)
    {
        ArgumentNullException.ThrowIfNull(top);

        var full = CaptureTopLevelStable(top);
        var bounds = new PixelRect(0, 0, full.Size.Width, full.Size.Height);
        var requested = ToPixelRect(region);
        var clipped = bounds.Intersect(requested);

        if (clipped.Width <= 0 || clipped.Height <= 0)
            throw new InvalidOperationException(
                $"The region [x={requested.X} y={requested.Y} w={requested.Width} h={requested.Height}] lies outside " +
                $"the window, which is {bounds.Width}x{bounds.Height}. Use get_app_info or get_visual_tree to find valid coordinates.");

        return Crop(full, clipped);
    }

    /// <summary>
    /// Cuts <paramref name="region"/> (in pixels) out of an already-captured image.
    /// </summary>
    public static CapturedImage Crop(CapturedImage source, PixelRect region)
    {
        var sourceStride = source.Size.Width * 4;
        var targetStride = region.Width * 4;
        var bgra = new byte[targetStride * region.Height];

        for (var y = 0; y < region.Height; y++)
        {
            Buffer.BlockCopy(
                source.Bgra, (region.Y + y) * sourceStride + region.X * 4,
                bgra, y * targetStride,
                targetStride);
        }

        var size = new PixelSize(region.Width, region.Height);
        return new CapturedImage(EncodePng(bgra, size), bgra, size);
    }

    /// <summary>
    /// Resizes a capture to <paramref name="target"/>.
    /// </summary>
    /// <remarks>
    /// Enlarging uses nearest-neighbour, which is not a stylistic choice: a pixel-art sprite or a
    /// hairline border blurred by interpolation is unreadable, and the whole point of enlarging a
    /// screenshot is to see the individual pixels. Shrinking box-averages instead, because
    /// nearest-neighbour would drop thin strokes and one-pixel text entirely. Both run on the captured
    /// buffer, so no re-render (and no renderer quirk) is involved.
    /// </remarks>
    public static CapturedImage Resample(CapturedImage source, PixelSize target)
    {
        if (target == source.Size)
            return source;

        var width = Math.Max(1, target.Width);
        var height = Math.Max(1, target.Height);
        var shrinking = width < source.Size.Width || height < source.Size.Height;
        var bgra = shrinking
            ? BoxDownscale(source, width, height)
            : NearestUpscale(source, width, height);

        var size = new PixelSize(width, height);
        return new CapturedImage(EncodePng(bgra, size), bgra, size);
    }

    /// <summary>
    /// Resolves the pixel size a capture should be delivered at. <paramref name="scale"/> multiplies
    /// (2 = double size, 0.5 = half); <paramref name="maxWidth"/> shrinks proportionally so the result
    /// is at most that wide, and never enlarges. Both are optional and <paramref name="maxWidth"/> is
    /// applied after <paramref name="scale"/>, so an agent can ask to enlarge yet still cap the payload.
    /// Returns null when the image should be delivered unchanged.
    /// </summary>
    public static PixelSize? ResolveTargetSize(PixelSize source, double? scale, int? maxWidth)
    {
        var width = (double)source.Width;
        var height = (double)source.Height;

        if (scale is { } factor && factor > 0 && Math.Abs(factor - 1) > 0.001)
        {
            width *= factor;
            height *= factor;
        }

        if (maxWidth is { } cap && cap > 0 && width > cap)
        {
            height *= cap / width;
            width = cap;
        }

        var target = new PixelSize(
            Math.Max(1, (int)Math.Round(width)),
            Math.Max(1, (int)Math.Round(height)));

        return target == source ? null : target;
    }

    private static byte[] NearestUpscale(CapturedImage source, int width, int height)
    {
        var sourceStride = source.Size.Width * 4;
        var targetStride = width * 4;
        var bgra = new byte[targetStride * height];

        for (var y = 0; y < height; y++)
        {
            var sourceY = Math.Min(source.Size.Height - 1, y * source.Size.Height / height);
            var sourceRow = sourceY * sourceStride;
            var targetRow = y * targetStride;

            for (var x = 0; x < width; x++)
            {
                var sourceIndex = sourceRow + Math.Min(source.Size.Width - 1, x * source.Size.Width / width) * 4;
                var targetIndex = targetRow + x * 4;
                bgra[targetIndex] = source.Bgra[sourceIndex];
                bgra[targetIndex + 1] = source.Bgra[sourceIndex + 1];
                bgra[targetIndex + 2] = source.Bgra[sourceIndex + 2];
                bgra[targetIndex + 3] = source.Bgra[sourceIndex + 3];
            }
        }

        return bgra;
    }

    private static byte[] BoxDownscale(CapturedImage source, int width, int height)
    {
        var sourceStride = source.Size.Width * 4;
        var targetStride = width * 4;
        var bgra = new byte[targetStride * height];

        for (var y = 0; y < height; y++)
        {
            var y0 = y * source.Size.Height / height;
            var y1 = Math.Max(y0 + 1, (y + 1) * source.Size.Height / height);

            for (var x = 0; x < width; x++)
            {
                var x0 = x * source.Size.Width / width;
                var x1 = Math.Max(x0 + 1, (x + 1) * source.Size.Width / width);

                long b = 0, g = 0, r = 0, a = 0;
                var samples = 0;
                for (var sy = y0; sy < y1; sy++)
                {
                    var row = sy * sourceStride;
                    for (var sx = x0; sx < x1; sx++)
                    {
                        var i = row + sx * 4;
                        b += source.Bgra[i];
                        g += source.Bgra[i + 1];
                        r += source.Bgra[i + 2];
                        a += source.Bgra[i + 3];
                        samples++;
                    }
                }

                var target = y * targetStride + x * 4;
                bgra[target] = (byte)(b / samples);
                bgra[target + 1] = (byte)(g / samples);
                bgra[target + 2] = (byte)(r / samples);
                bgra[target + 3] = (byte)(a / samples);
            }
        }

        return bgra;
    }

    private static PixelRect ToPixelRect(Rect region) =>
        new(
            (int)Math.Floor(region.X),
            (int)Math.Floor(region.Y),
            Math.Max(1, (int)Math.Ceiling(region.Width)),
            Math.Max(1, (int)Math.Ceiling(region.Height)));

    /// <summary>
    /// Encodes a raw BGRA8888 buffer as PNG (used to render diff/overlay images).
    /// </summary>
    public static byte[] EncodePng(byte[] bgra, PixelSize size)
    {
        ArgumentNullException.ThrowIfNull(bgra);
        using var writeable = new WriteableBitmap(size, StandardDpi, PixelFormat.Bgra8888, AlphaFormat.Premul);
        using (var frameBuffer = writeable.Lock())
        {
            var stride = size.Width * 4;
            for (var y = 0; y < size.Height; y++)
                Marshal.Copy(bgra, y * stride, IntPtr.Add(frameBuffer.Address, y * frameBuffer.RowBytes), stride);
        }

        using var stream = new MemoryStream();
        writeable.Save(stream);
        return stream.ToArray();
    }

    private static RenderTargetBitmap RenderControl(Control control, ScreenshotMode mode)
    {
        ArgumentNullException.ThrowIfNull(control);
        EnsureLaidOut(control);

        if (mode == ScreenshotMode.InContext && TopLevel.GetTopLevel(control) is { } top)
            return RenderControlInContext(control, top);

        return RenderToBitmap(control, control.Bounds.Size);
    }

    private static RenderTargetBitmap RenderControlInContext(Control control, TopLevel top)
    {
        var topSize = ResolveTopLevelSize(top);
        using var full = new RenderTargetBitmap(ToPixelSize(topSize), StandardDpi);
        full.Render(top);

        var origin = control.TranslatePoint(new Point(0, 0), top) ?? new Point(0, 0);
        var size = control.Bounds.Size;
        if (size.Width <= 0 || size.Height <= 0)
            throw new InvalidOperationException(
                $"Control '{DescribeControl(control)}' has a zero size and cannot be captured.");

        var cropped = new RenderTargetBitmap(ToPixelSize(size), StandardDpi);
        using (var ctx = cropped.CreateDrawingContext())
        {
            ctx.DrawImage(
                full,
                new Rect(origin.X, origin.Y, size.Width, size.Height),
                new Rect(0, 0, size.Width, size.Height));
        }

        return cropped;
    }

    private static RenderTargetBitmap RenderToBitmap(Visual visual, Size size)
    {
        if (size.Width <= 0 || size.Height <= 0)
            throw new InvalidOperationException(
                $"Visual '{visual.GetType().Name}' has a zero size and cannot be captured. " +
                "It may be collapsed, not yet laid out, or off-screen.");

        var rtb = new RenderTargetBitmap(ToPixelSize(size), StandardDpi);
        rtb.Render(visual);
        return rtb;
    }

    private static byte[] Encode(RenderTargetBitmap bitmap)
    {
        using var stream = new MemoryStream();
        bitmap.Save(stream);
        return stream.ToArray();
    }

    /// <remarks>
    /// The raw buffer must really be BGRA, as <see cref="CapturedImage"/> promises: <see cref="Crop"/>,
    /// <see cref="Resample"/> and the compare diff all rebuild a PNG from it through a
    /// <see cref="PixelFormat.Bgra8888"/> <see cref="WriteableBitmap"/>, and the diff's marker color is a
    /// BGRA constant.
    /// <para>
    /// <b>Which is why the copy goes through a locked framebuffer.</b> The
    /// <c>CopyPixels(PixelRect, IntPtr, …)</c> overload copies in the bitmap's <em>own</em> format, and that
    /// is platform-dependent — <c>Bgra8888</c> on Windows but <c>Rgba8888</c> on macOS — so reading it as
    /// BGRA swapped red and blue in every image rebuilt from the buffer (a `screenshot_region` crop, any
    /// scaled capture, the compare diff) while a directly-saved capture looked fine. Copying into a
    /// framebuffer declared Bgra8888 makes the platform convert, so the invariant holds everywhere.
    /// </para>
    /// </remarks>
    private static CapturedImage Capture(RenderTargetBitmap bitmap)
    {
        var png = Encode(bitmap);
        var size = bitmap.PixelSize;
        var stride = size.Width * 4;
        var bgra = new byte[stride * size.Height];

        using var normalized = new WriteableBitmap(size, StandardDpi, PixelFormat.Bgra8888, AlphaFormat.Premul);
        using (var frameBuffer = normalized.Lock())
        {
            bitmap.CopyPixels(frameBuffer);

            for (var y = 0; y < size.Height; y++)
                Marshal.Copy(IntPtr.Add(frameBuffer.Address, y * frameBuffer.RowBytes), bgra, y * stride, stride);
        }

        return new CapturedImage(png, bgra, size);
    }

    private static void EnsureLaidOut(Control control)
    {
        // A control already in the visual tree has valid bounds; only force layout for a detached or
        // never-measured control, so we never disturb a live layout.
        if (control.Bounds.Width > 0 && control.Bounds.Height > 0)
            return;

        if (TopLevel.GetTopLevel(control) is not null)
            return;

        control.Measure(Size.Infinity);
        control.Arrange(new Rect(control.DesiredSize));
    }

    private static Size ResolveTopLevelSize(TopLevel top)
    {
        var bounds = top.Bounds.Size;
        if (bounds.Width > 0 && bounds.Height > 0)
            return bounds;

        return top.ClientSize;
    }

    private static PixelSize ToPixelSize(Size size) =>
        new(
            Math.Max(1, (int)Math.Ceiling(size.Width)),
            Math.Max(1, (int)Math.Ceiling(size.Height)));

    private static string DescribeControl(Control control) =>
        string.IsNullOrEmpty(control.Name) ? control.GetType().Name : $"{control.GetType().Name} ('{control.Name}')";
}
