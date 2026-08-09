using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Avalonia.Markup.Declarative.Diagnostics;
using Avalonia.Threading;
using Declarative.Avalonia.AgentTools;
using Declarative.Avalonia.AgentTools.Tools;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Protocol;

namespace Declarative.Avalonia.AgentTools.Tests;

/// <summary>
/// Smoke test that drives EVERY MCP tool over <see cref="AgentDemoView"/> and asserts the P1–P6
/// acceptance criteria. The tools are the real static handlers; they marshal to the UI thread (already
/// current under <c>[AvaloniaFact]</c>) and resolve the window through the component registry.
/// </summary>
public class AgentToolsSmokeTests
{
    static AgentToolsSmokeTests() =>
        AgentToolContext.Options = new AgentInspectorOptions { EnableInteraction = true };

    // These [AvaloniaFact]s share one Application/dispatcher for the whole assembly. Each test gets a
    // fresh window (a freshly shown window renders into the compositor's hit-test scene, which real
    // pointer routing uses); leftover windows are torn down first so exactly one top-level is discoverable.
    private static (Window Window, AgentDemoView View, AgentDemoViewModel Vm) ShowDemo()
    {
        foreach (var leftover in AgentToolContext.GetTopLevels().OfType<Window>().ToList())
        {
            leftover.Content = null; // detach → unregister the view synchronously
            leftover.Close();
        }
        Dispatcher.UIThread.RunJobs();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Dispatcher.UIThread.RunJobs();

        var view = new AgentDemoView();
        // Set the window DataContext too, so the escape hatches' default (main-window) target resolves —
        // the nested-state P3 scenario is still exercised via AppState.UiState.ShowBrushSettings.
        var window = new Window { Width = 520, Height = 520, Title = "AgentDemo", Content = view, DataContext = view.ViewModel };
        window.Show();
        window.Activate();
        Dispatcher.UIThread.RunJobs();
        global::Avalonia.Headless.AvaloniaHeadlessPlatform.ForceRenderTimerTick();
        Dispatcher.UIThread.RunJobs();
        return (window, view, (AgentDemoViewModel)view.ViewModel!);
    }

    private static void ResetDemo(Window window)
    {
        window.Content = null;
        window.Close();
        Dispatcher.UIThread.RunJobs();
    }

    private static Rect SliderBounds(Window window)
    {
        var slider = AgentToolContext.FindControl("RawSlider")!;
        Assert.NotNull(slider);
        var bounds = VisualBoundsHelper.GetClientBounds(slider, window);
        Assert.NotNull(bounds);
        return bounds!.Value;
    }

    private static (bool IsError, string Text, bool HasImage) Unpack(CallToolResult result)
    {
        var text = string.Join("\n", result.Content.OfType<TextContentBlock>().Select(b => b.Text));
        var hasImage = result.Content.OfType<ImageContentBlock>().Any();
        return (result.IsError is true, text, hasImage);
    }

    // ── P1: real pointer input drives a raw-pointer control ──────────────────────────────────────

    [AvaloniaFact]
    public async Task P1_drag_scrubs_raw_slider_with_no_automation_peer()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            Assert.Equal(0, vm.Value);

            var b = SliderBounds(window);
            var y = b.Center.Y;
            var from = new Point(b.X + b.Width * 0.1, y);
            var to = new Point(b.X + b.Width * 0.8, y);

            var result = await InteractionTools.Drag(from.X, from.Y, to.X, to.Y, "Left", 12, 0, null, null);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("drag Left", result);
            // The custom Border slider scrubbed to ~80% purely from synthesized real pointer input.
            Assert.True(vm.Value > 50, $"expected value scrubbed past 50, got {vm.Value}. ({result})");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task P1_tap_enters_text_edit_mode_without_a_peer()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            Assert.False(vm.IsEditing);

            var b = SliderBounds(window);
            var result = await InteractionTools.Tap(b.Center.X, b.Center.Y, null, null, null);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("tap Left", result);
            Assert.True(vm.IsEditing, $"tap should have entered edit mode. ({result})");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task P1_escape_and_enter_reach_focused_textbox()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var editor = (TextBox)AgentToolContext.FindControl("ValueEditor")!;
            editor.Focus();
            Dispatcher.UIThread.RunJobs();
            Assert.True(editor.IsFocused, "editor should be focused before pressing keys.");

            var escape = await InteractionTools.Invoke(null, "key", "Escape");
            Dispatcher.UIThread.RunJobs();
            Assert.Equal("Escape", vm.LastKey);

            var enter = await InteractionTools.Invoke(null, "key", "Enter");
            Dispatcher.UIThread.RunJobs();
            // Avalonia parses Enter to Key.Return.
            Assert.True(vm.LastKey is "Enter" or "Return", $"expected Enter/Return, got {vm.LastKey}");

            Assert.Contains("real input", escape);
            Assert.Contains("real input", enter);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task P1_pointer_press_move_release_gesture_scrubs()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var b = SliderBounds(window);
            var y = b.Center.Y;

            await InteractionTools.PointerPress(b.X + b.Width * 0.1, y, "Left", null, null);
            await InteractionTools.PointerMove(b.X + b.Width * 0.5, y, null, null);
            await InteractionTools.PointerMove(b.X + b.Width * 0.9, y, null, null);
            var release = await InteractionTools.PointerRelease(b.X + b.Width * 0.9, y, "Left", null, null);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("pointer release", release);
            Assert.True(vm.Value > 50, $"press/move/release gesture should scrub the slider, got {vm.Value}.");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task ClickAt_uses_real_pointer_by_default()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var b = SliderBounds(window);
            var result = await InteractionTools.ClickAt(b.Center.X, b.Center.Y, null, null);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("real pointer", result);
            // A click at the slider (no scrub) is a tap → edit mode, proving real pointer delivery.
            Assert.True(vm.IsEditing);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── Custom-canvas input: double click, wheel, pen pressure, multi-touch ──────────────────────

    private static Rect CanvasBounds(Window window)
    {
        var canvas = AgentToolContext.FindControl("CanvasSurface")!;
        Assert.NotNull(canvas);
        var bounds = VisualBoundsHelper.GetClientBounds(canvas, window);
        Assert.NotNull(bounds);
        return bounds!.Value;
    }

    [AvaloniaFact]
    public async Task Tap_with_count_2_delivers_a_real_double_click()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            await InteractionTools.Tap(c.X, c.Y, null, null, null);
            Dispatcher.UIThread.RunJobs();
            Assert.Equal(1, vm.LastClickCount);

            var result = await InteractionTools.Tap(c.X, c.Y, null, null, null, count: 2);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("2x tap", result);
            Assert.Equal(2, vm.LastClickCount);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Single_taps_never_accumulate_into_a_double_click()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            // Back-to-back single taps at the identical point are well inside the platform double-click
            // window; the streak reset is what keeps each of them ClickCount == 1.
            for (var i = 0; i < 3; i++)
            {
                await InteractionTools.Tap(c.X, c.Y, null, null, null);
                Dispatcher.UIThread.RunJobs();
                Assert.Equal(1, vm.LastClickCount);
            }
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Pointer_wheel_reaches_a_raw_canvas_in_notches()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            var result = await InteractionTools.PointerWheel(c.X, c.Y, 0, 3);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("wheel", result);
            Assert.Equal(1, vm.WheelEventCount);
            Assert.Equal(3, vm.LastWheelDelta.Y);

            // Ctrl+wheel (the usual zoom gesture) still arrives as one notched event.
            await InteractionTools.PointerWheel(c.X, c.Y, 0, -1, "Ctrl");
            Dispatcher.UIThread.RunJobs();
            Assert.Equal(2, vm.WheelEventCount);
            Assert.Equal(-1, vm.LastWheelDelta.Y);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Precision_wheel_arrives_as_a_burst_of_fractional_deltas()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            await InteractionTools.PointerWheel(c.X, c.Y, 0, 1, null, null, precision: true);
            Dispatcher.UIThread.RunJobs();

            // A touchpad is told apart from a wheel by the shape of the deltas: many small fractional
            // steps rather than one whole notch, summing to the requested amount.
            Assert.True(vm.WheelEventCount > 1, $"expected a multi-event burst, got {vm.WheelEventCount}.");
            Assert.NotEqual(0, vm.LastWheelDelta.Y);
            Assert.True(Math.Abs(vm.LastWheelDelta.Y) < 1, $"expected a fractional step, got {vm.LastWheelDelta.Y}.");
            Assert.Equal(1.0, vm.AccumulatedWheelDelta.Y, 6);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Pen_press_reports_pressure_and_the_inverted_eraser_end()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            var result = await InteractionTools.Tap(c.X, c.Y, null, null, null, 1, "pen", 0.3);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("pen", result);
            Assert.Equal(PointerType.Pen, vm.LastPointerType);
            Assert.Equal(0.3f, vm.LastPressure, 3);
            Assert.False(vm.LastIsEraser);

            await InteractionTools.Tap(c.X, c.Y, null, null, null, 1, "pen", 0.9, inverted: true);
            Dispatcher.UIThread.RunJobs();

            Assert.Equal(0.9f, vm.LastPressure, 3);
            Assert.True(vm.LastIsEraser, "an inverted pen must report IsEraser.");
            Assert.True(vm.LastIsInverted, "an inverted pen must report IsInverted.");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Unknown_pointer_type_is_reported_not_silently_downgraded()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;
            var result = await InteractionTools.Tap(c.X, c.Y, null, null, null, 1, "trackball");

            Assert.Contains("Unknown pointerType", result);
            Assert.Contains("mouse | pen | touch", result);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Two_fingers_can_be_down_at_once()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var b = CanvasBounds(window);
            var y = b.Center.Y;

            // One finger: press and release both route to the control.
            await InteractionTools.TouchPress(1, b.Center.X, y);
            Dispatcher.UIThread.RunJobs();
            Assert.Equal(1, vm.ContactCount);
            Assert.Equal(PointerType.Touch, vm.LastPointerType);

            await InteractionTools.TouchRelease(1, b.Center.X, y);
            Dispatcher.UIThread.RunJobs();
            Assert.Equal(0, vm.ContactCount);

            // Two fingers with distinct ids are down simultaneously — what a mouse cannot express.
            await InteractionTools.TouchPress(1, b.X + 20, y);
            var second = await InteractionTools.TouchPress(2, b.Right - 20, y);
            Dispatcher.UIThread.RunJobs();
            Assert.Equal(2, vm.ContactCount);
            Assert.Contains("2 contact(s) down", second);

            // A move for a finger that was never pressed is a named error, not a silent no-op.
            var stray = await InteractionTools.TouchMove(7, b.Center.X, y);
            Assert.Contains("not down", stray);

            // Asserted on the tool's own contact bookkeeping rather than the view-model: once a second
            // finger lands the canvas' PinchGestureRecognizer captures both pointers, so Avalonia routes
            // their release to the recognizer instead of back to the control. That is real behaviour —
            // the single-finger case above is what proves release routing itself works.
            await InteractionTools.TouchRelease(1, b.X + 20, y);
            var last = await InteractionTools.TouchRelease(2, b.Right - 20, y);
            Dispatcher.UIThread.RunJobs();
            Assert.Contains("0 contact(s) still down", last);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Pinch_raises_a_real_pinch_event()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var c = CanvasBounds(window).Center;

            var result = await InteractionTools.Pinch(c.X, c.Y, 40, 160, 12);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("spread", result);
            Assert.True(vm.PinchEventCount > 0, "the PinchGestureRecognizer should have raised PinchEvent.");
            Assert.True(vm.LastPinchScale > 1, $"a spread should scale up, got {vm.LastPinchScale}.");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── P2: structured, actionable escape-hatch errors ───────────────────────────────────────────

    [AvaloniaFact]
    public async Task P2_invoke_command_bad_path_returns_structured_error()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var result = await InteractionTools.InvokeCommandTool(null, "ViewCommands.ToggleBrushSettingsCommand", null);

            Assert.DoesNotContain("An error occurred", result);
            Assert.Contains("no member 'ViewCommands'", result);
            Assert.Contains("AgentDemoViewModel", result);
            Assert.Contains("Available ICommand properties", result);
            Assert.Contains("ToggleBrushSettingsCommand", result);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task P2_invoke_command_good_path_executes()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            Assert.False(vm.AppState.UiState.ShowBrushSettings);
            var result = await InteractionTools.InvokeCommandTool(null, "ToggleBrushSettingsCommand", null);
            Dispatcher.UIThread.RunJobs();

            Assert.Contains("Executed command", result);
            Assert.True(vm.AppState.UiState.ShowBrushSettings);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── P3: list_bindable + deep-path targeting reaches nested app state ──────────────────────────

    [AvaloniaFact]
    public async Task P3_list_bindable_reveals_nested_state_and_deep_set_opens_popup()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var bindable = await InteractionTools.ListBindable(null);
            Assert.Contains("AppState", bindable);
            Assert.Contains("ToggleBrushSettingsCommand", bindable);
            Assert.Contains("Sub-objects", bindable);

            // A wrong shallow path is diagnostic about what actually exists.
            var wrong = await InteractionTools.SetViewModel(null, "ShowBrushSettings", "true");
            Assert.Contains("no member 'ShowBrushSettings'", wrong);

            // The deep path resolves and flips the real state, opening the bound popup.
            var deep = await InteractionTools.SetViewModel(null, "AppState.UiState.ShowBrushSettings", "true");
            Dispatcher.UIThread.RunJobs();
            Assert.Contains("ShowBrushSettings", deep);
            Assert.True(vm.AppState.UiState.ShowBrushSettings);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── P4: one coordinate frame; visual-tree center round-trips through hit_test ────────────────

    [AvaloniaFact]
    public async Task P4_visual_tree_center_round_trips_through_hit_test()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var tree = await InspectionTools.GetVisualTree(null, null, "RawSlider");
            Assert.Contains("#RawSlider", tree);
            Assert.Contains("abs=", tree);
            Assert.Contains("center=", tree);

            // Take the slider's absolute center (the frame the tree reports) and hit_test it.
            var b = SliderBounds(window);
            var hit = await InspectionTools.HitTest(b.Center.X, b.Center.Y, null);

            Assert.Contains("#RawSlider", hit);
            // P7: the topmost control there is a raw Border, so the drivability hint says pointer-only.
            Assert.Contains("raw-pointer-only", hit);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── P5 + P6: closed popup is guided open, then captured with a rendered frame ─────────────────

    [AvaloniaFact]
    public async Task P5_P6_closed_popup_hint_then_open_and_capture()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            // P5: screenshotting the closed popup is a guided dead-end, not a bare "zero size".
            var closed = Unpack(await InspectionTools.ScreenshotControl("BrushSettingsPopup", null));
            Assert.True(closed.IsError);
            Assert.Contains("open_popup", closed.Text);

            // Regression: a container that merely *contains* the closed popup is NOT mistaken for one —
            // it captures normally.
            var container = Unpack(await InspectionTools.ScreenshotControl("DemoRoot", null));
            Assert.False(container.IsError, container.Text);
            Assert.True(container.HasImage);

            // open_popup opens it in one call.
            var opened = await InteractionTools.OpenPopup("BrushSettingsPopup");
            Dispatcher.UIThread.RunJobs();
            Assert.Contains("Opened popup", opened);
            Assert.True(vm.AppState.UiState.ShowBrushSettings);

            // P6: capturing right after opening yields a rendered (non-degenerate) frame.
            var shot = Unpack(await InspectionTools.ScreenshotControl("BrushSettings", null));
            Assert.False(shot.IsError, shot.Text);
            Assert.True(shot.HasImage);

            var frame = ControlScreenshotService.CaptureTopLevelStable(window);
            Assert.False(ControlScreenshotService.IsDegenerate(frame.Bgra), "captured frame should not be empty/flat.");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Popup_opens_via_click_trigger_too()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            var b = VisualBoundsHelper.GetClientBounds(AgentToolContext.FindControl("OpenByClick")!, window)!.Value;
            await InteractionTools.Tap(b.Center.X, b.Center.Y, null, null, null);
            Dispatcher.UIThread.RunJobs();

            Assert.True(vm.AppState.UiState.ShowBrushSettings, "clicking the trigger button should open the popup.");
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── Screenshots: regions and scaling ─────────────────────────────────────────────────────────

    [AvaloniaFact]
    public async Task Screenshot_region_crops_the_window_in_the_shared_coordinate_frame()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var b = CanvasBounds(window);

            var shot = Unpack(await InspectionTools.ScreenshotRegion(b.X, b.Y, b.Width, b.Height));
            Assert.False(shot.IsError, shot.Text);
            Assert.True(shot.HasImage);

            // Regions go into the same store as full captures, so compare_screenshots works on them.
            var latest = ScreenshotStore.List()[^1];
            Assert.Contains("Region", latest.Label);
            Assert.Equal((int)Math.Ceiling(b.Width), latest.Image.Size.Width);
            Assert.Equal((int)Math.Ceiling(b.Height), latest.Image.Size.Height);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Screenshot_region_scale_enlarges_and_max_width_shrinks()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var b = CanvasBounds(window);

            var enlarged = Unpack(await InspectionTools.ScreenshotRegion(b.X, b.Y, 20, 10, null, scale: 8));
            Assert.False(enlarged.IsError, enlarged.Text);
            Assert.Contains("nearest-neighbour", enlarged.Text);
            Assert.Equal(new PixelSize(160, 80), ScreenshotStore.List()[^1].Image.Size);

            var shrunk = Unpack(await InspectionTools.ScreenshotRegion(b.X, b.Y, 200, 40, null, maxWidth: 50));
            Assert.False(shrunk.IsError, shrunk.Text);
            Assert.Contains("box-averaged", shrunk.Text);
            Assert.Equal(50, ScreenshotStore.List()[^1].Image.Size.Width);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Screenshot_region_outside_the_window_explains_itself()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var far = Unpack(await InspectionTools.ScreenshotRegion(10_000, 10_000, 100, 100));
            Assert.True(far.IsError);
            Assert.Contains("outside", far.Text);

            var empty = Unpack(await InspectionTools.ScreenshotRegion(0, 0, 0, 10));
            Assert.True(empty.IsError);
            Assert.Contains("positive size", empty.Text);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Screenshot_window_max_width_caps_the_payload()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var shot = Unpack(await InspectionTools.ScreenshotWindow(null, false, null, null, maxWidth: 120));
            Assert.False(shot.IsError, shot.Text);
            Assert.Contains("delivered at 120x", shot.Text);
            Assert.Equal(120, ScreenshotStore.List()[^1].Image.Size.Width);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── get_logs / get_render_stats ──────────────────────────────────────────────────────────────

    [AvaloniaFact]
    public void Get_logs_returns_console_output_and_filters_it()
    {
        AppLogBuffer.Clear();

        // Stand in for the developer's terminal so we can prove the tee forwards everything to it.
        var terminal = new StringWriter();
        var realOut = Console.Out;
        Console.SetOut(terminal);

        AppLogSink.Install();
        try
        {
            Console.WriteLine("agent-tools-marker: something happened");
            Console.Error.WriteLine("agent-tools-marker: and this went wrong");

            Assert.Contains("agent-tools-marker: something happened", terminal.ToString());

            var all = InspectionTools.GetLogs();
            Assert.Contains("something happened", all);
            Assert.Contains("and this went wrong", all);

            var errorsOnly = InspectionTools.GetLogs(null, "error");
            Assert.DoesNotContain("something happened", errorsOnly);
            Assert.Contains("and this went wrong", errorsOnly);

            var filtered = InspectionTools.GetLogs(null, null, "went wrong");
            Assert.Contains("and this went wrong", filtered);
            Assert.DoesNotContain("something happened", filtered);

            Assert.Contains("not a valid ISO-8601", InspectionTools.GetLogs("yesterday"));
            Assert.Contains("Unknown level", InspectionTools.GetLogs(null, "shouty"));
        }
        finally
        {
            AppLogSink.Uninstall();
            AppLogBuffer.Clear();
            Console.SetOut(realOut);
        }
    }

    [AvaloniaFact]
    public void Get_logs_since_timestamp_excludes_older_lines()
    {
        AppLogBuffer.Clear();
        AppLogSink.Install();
        try
        {
            Console.WriteLine("agent-tools-marker: before");
            var cut = DateTimeOffset.Now.AddMilliseconds(1);
            Thread.Sleep(5);
            Console.WriteLine("agent-tools-marker: after");

            var recent = InspectionTools.GetLogs(cut.ToString("O"));
            Assert.Contains("after", recent);
            Assert.DoesNotContain("before", recent);
        }
        finally
        {
            AppLogSink.Uninstall();
            AppLogBuffer.Clear();
        }
    }

    [AvaloniaFact]
    public async Task Get_render_stats_reports_size_scaling_and_layout_cost()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            var stats = await InspectionTools.GetRenderStats(null, 0);

            Assert.Contains("AgentDemo", stats);
            Assert.Contains("Client size:", stats);
            Assert.Contains("Visuals in tree:", stats);
            Assert.Contains("Last layout run:", stats);
            Assert.Contains("Debug overlays:", stats);
            // Read-only: sampling must not have switched an overlay on.
            Assert.Contains("Debug overlays: None", stats);
        }
        finally
        {
            ResetDemo(window);
        }
    }

    // ── P2: host-supplied tool types ─────────────────────────────────────────────────────────────

    [Fact]
    public void Host_tools_are_registered_with_services_injected()
    {
        var services = new ServiceCollection()
            .AddSingleton(new HostAppState { CurrentDocument = "sprite.png" })
            .BuildServiceProvider();

        var options = new AgentInspectorOptions { Services = services }.WithTools<HostSceneTools>();

        Assert.Equal(new[] { typeof(HostSceneTools) }, options.ToolTypes);

        var tools = AgentInspectorServer.CreateHostTools(options, typeof(HostSceneTools));
        Assert.Contains(tools, t => t.ProtocolTool.Name == "host_describe_document");
    }

    [Fact]
    public void Host_tools_marked_interactive_are_gated_by_EnableInteraction()
    {
        var readOnly = new AgentInspectorOptions().WithTools<HostSceneTools>();
        var interactive = new AgentInspectorOptions().WithTools<HostEditTools>();

        Assert.False(AgentInspectorOptions.RequiresInteraction(typeof(HostSceneTools)));
        Assert.True(AgentInspectorOptions.RequiresInteraction(typeof(HostEditTools)));

        // Registration is per type, so a host's read-only tools stay available with interaction off.
        Assert.Single(readOnly.ToolTypes);
        Assert.Single(interactive.ToolTypes);
    }

    [Fact]
    public void Registering_a_type_without_tool_methods_fails_loudly()
    {
        var ex = Assert.Throws<ArgumentException>(() => new AgentInspectorOptions().WithTools<HostAppState>());
        Assert.Contains("[McpServerTool]", ex.Message);
    }

    [Fact]
    public void Host_tools_without_services_need_a_parameterless_constructor()
    {
        var options = new AgentInspectorOptions().WithTools<HostSceneTools>();

        var ex = Assert.Throws<InvalidOperationException>(
            () => AgentInspectorServer.CreateHostTools(options, typeof(HostSceneTools)));
        Assert.Contains("AgentInspectorOptions.Services", ex.Message);
    }

    // ── Every remaining tool runs green over the demo ────────────────────────────────────────────

    [AvaloniaFact]
    public async Task All_readonly_tools_run_over_demo()
    {
        var (window, _, _) = ShowDemo();
        try
        {
            Assert.Contains("Windows/top-levels", await InspectionTools.GetAppInfo());
            Assert.Contains("#RawSlider", await InspectionTools.GetVisualTree(null, null, null));
            Assert.Contains("Frame:", await InspectionTools.GetVisualTree(null, null, null));
            Assert.Contains("AgentDemoView", await InspectionTools.ListComponents());
            Assert.Contains("Bounds:", await InspectionTools.GetLayout("RawSlider"));
            Assert.NotNull(await InspectionTools.LayoutAudit(null));
            Assert.Contains("Button", await InspectionTools.FindText("Open (command)"));
            Assert.Contains("RawSlider", await InspectionTools.GetProperties("RawSlider", null));
            Assert.NotNull(await InspectionTools.GetPropertySources("RawSlider", null));
            Assert.Contains("AgentDemoViewModel", await InspectionTools.GetDataContext("DemoRoot", 2));
            Assert.Contains("AgentDemoView", await InspectionTools.GetSource("RawSlider"));
            Assert.Equal("UI thread is idle.", await InspectionTools.WaitIdle());
            Assert.Contains("RawSlider", await InspectionTools.WaitFor("RawSlider", "exists", 2000));
            Assert.NotNull(InspectionTools.GetErrors(null));

            var window1 = Unpack(await InspectionTools.ScreenshotWindow(null, false, null));
            Assert.False(window1.IsError, window1.Text);
            Assert.True(window1.HasImage);

            var annotated = Unpack(await InspectionTools.ScreenshotWindow(null, true, null));
            Assert.True(annotated.HasImage);

            var listed = await InspectionTools.ListScreenshots();
            Assert.Contains("screenshot", listed);

            var compared = Unpack(await InspectionTools.CompareScreenshots(null, null));
            Assert.False(compared.IsError, compared.Text);

            var highlighted = Unpack(await InspectionTools.Highlight("RawSlider", null, "#00A0FF"));
            Assert.True(highlighted.HasImage);
            Unpack(await InspectionTools.Highlight(null, "clear", null));
        }
        finally
        {
            ResetDemo(window);
        }
    }

    [AvaloniaFact]
    public async Task Remaining_interaction_tools_run_over_demo()
    {
        var (window, _, vm) = ShowDemo();
        try
        {
            // set_theme / set_window_size
            Assert.Contains("Theme", await InteractionTools.SetTheme("Dark"));
            Assert.Contains("Resized", await InteractionTools.SetWindowSize(460, 460, null));

            // invoke: focus, set, key, type against named controls
            Assert.Contains("Focused", await InteractionTools.Invoke("OpenByCommand", "focus", null));
            Assert.Contains("Invoked", await InteractionTools.Invoke("OpenByCommand", "invoke", null));
            Dispatcher.UIThread.RunJobs();
            Assert.True(vm.AppState.UiState.ShowBrushSettings); // the command ran

            // type into the (focused) editor via real text input
            var editor = (TextBox)AgentToolContext.FindControl("ValueEditor")!;
            editor.Focus();
            var typed = await InteractionTools.Invoke("ValueEditor", "type", "42");
            Dispatcher.UIThread.RunJobs();
            Assert.Contains("Typed", typed);

            // list_bindable by control name
            Assert.Contains("Bindable surface", await InteractionTools.ListBindable("DemoRoot"));
        }
        finally
        {
            ResetDemo(window);
        }
    }
}
