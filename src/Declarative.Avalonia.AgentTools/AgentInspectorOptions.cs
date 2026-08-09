using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using ModelContextProtocol.Server;

namespace Declarative.Avalonia.AgentTools;

/// <summary>
/// Marks a host-supplied tool type as part of the <em>interaction</em> tier, so it is registered only
/// when <see cref="AgentInspectorOptions.EnableInteraction"/> is set.
/// </summary>
/// <remarks>
/// Host tools are gated per type rather than as a block: an app typically has read-only tools worth
/// exposing all the time (dump the scene graph, read the selection) and state-changing ones that belong
/// behind the same switch as <c>tap</c> and <c>invoke</c>. Put this on the latter. Un-attributed host
/// tool types are registered whenever the inspector runs.
/// </remarks>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class AgentInteractionToolsAttribute : Attribute
{
}

/// <summary>
/// Configuration for the in-process agent inspector MCP server.
/// </summary>
public sealed class AgentInspectorOptions
{
    private readonly List<Type> _toolTypes = new();

    /// <summary>
    /// The only address the server ever binds to. The inspector is loopback-only by design: it can
    /// return screenshots that may contain sensitive data, and it is meant for local development.
    /// </summary>
    public const string LoopbackAddress = "127.0.0.1";

    /// <summary>
    /// The loopback TCP port the MCP HTTP/SSE endpoint listens on. Default: 5599.
    /// </summary>
    public int Port { get; set; } = 5599;

    /// <summary>
    /// Enables the tier-2 remote-control tools (<c>invoke</c>, <c>set_window_size</c>, <c>set_theme</c>,
    /// <c>click_at</c>, <c>tap</c>, <c>drag</c>, <c>pointer_*</c>, <c>touch_*</c>, <c>pinch</c>,
    /// <c>set_view_model</c>, <c>invoke_command</c>) — click / select / set value / focus / resize /
    /// switch theme / synthesize real pointer, wheel, pen and touch input, plus writing view-model state
    /// and running commands directly. This is a remote-control surface, so it is <see langword="false"/>
    /// by default and must be opted into explicitly. It also gates host tool types marked with
    /// <see cref="AgentInteractionToolsAttribute"/>.
    /// </summary>
    public bool EnableInteraction { get; set; }

    /// <summary>
    /// Records the <c>file:line</c> where each named control is declared (via <c>.Name(...)</c>) so
    /// <c>get_source</c> can point at the exact line. Off by default because it touches a hot construction
    /// path; enable it only while iterating with an agent.
    /// </summary>
    public bool EnableSourceTagging { get; set; }

    /// <summary>
    /// Buffers the app's log output in memory so <c>get_logs</c> can return it. On by default: with the
    /// app started from an IDE there is no stdout the agent can read.
    /// </summary>
    public bool CaptureLogs { get; set; } = true;

    /// <summary>
    /// Whether <see cref="CaptureLogs"/> also tees <see cref="Console.Out"/>/<see cref="Console.Error"/>.
    /// On by default, and transparent — the original writers still receive everything. It has its own
    /// switch because it is the one part that replaces process-global state.
    /// </summary>
    public bool CaptureConsole { get; set; } = true;

    /// <summary>
    /// The application's own service provider, used to construct the tool types registered with
    /// <see cref="WithTools{TTools}"/>.
    /// </summary>
    /// <remarks>
    /// The inspector's HTTP host has its own DI container, which knows nothing about the app's services.
    /// Setting this makes host tools resolve their constructor dependencies (the app state, command
    /// service, document model, …) from the <em>running application</em> instead. Leave it null if your
    /// tool types have parameterless constructors or only static tool methods.
    /// </remarks>
    public IServiceProvider? Services { get; set; }

    /// <summary>
    /// The host-supplied tool types registered with <see cref="WithTools{TTools}"/>/<see cref="AddTools"/>.
    /// </summary>
    public IReadOnlyList<Type> ToolTypes => _toolTypes;

    /// <summary>
    /// Registers an application tool type, exposing its <c>[McpServerTool]</c> methods alongside the
    /// built-in ones.
    /// </summary>
    /// <remarks>
    /// This is how an agent reaches anything the generic tools cannot see. To the inspector a custom
    /// drawing surface is one opaque <c>Control</c> filling the window; the scene, layers, frames,
    /// selection and pixels inside it are reachable only through tools the app writes itself. Instance
    /// methods are invoked on a single instance built once from <see cref="Services"/>, so a tool can
    /// take the app's real services in its constructor.
    /// </remarks>
    /// <typeparam name="TTools">
    /// A class with <c>[McpServerTool]</c>-attributed methods (conventionally also marked
    /// <c>[McpServerToolType]</c>).
    /// </typeparam>
    public AgentInspectorOptions WithTools<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TTools>()
        where TTools : class =>
        AddTools(typeof(TTools));

    /// <summary>
    /// Non-generic form of <see cref="WithTools{TTools}"/>, for registering tool types resolved at
    /// runtime. Registering the same type twice is a no-op.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// <paramref name="toolType"/> has no <c>[McpServerTool]</c> methods — almost always a forgotten
    /// attribute, and failing at startup beats an agent finding the tool missing later.
    /// </exception>
    public AgentInspectorOptions AddTools(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type toolType)
    {
        ArgumentNullException.ThrowIfNull(toolType);

        if (_toolTypes.Contains(toolType))
            return this;

        if (!GetToolMethods(toolType).Any())
        {
            throw new ArgumentException(
                $"'{toolType.FullName}' has no methods marked with [McpServerTool], so it would expose nothing. " +
                "Add the attribute to the methods you want the agent to call.",
                nameof(toolType));
        }

        _toolTypes.Add(toolType);
        return this;
    }

    /// <summary>
    /// The MCP endpoint URL the server listens on, derived from <see cref="LoopbackAddress"/> and
    /// <see cref="Port"/>.
    /// </summary>
    public string EndpointUrl => $"http://{LoopbackAddress}:{Port}";

    /// <summary>
    /// The <c>[McpServerTool]</c> methods on <paramref name="toolType"/>, public or not, static or not,
    /// declared or inherited — matching what the MCP SDK's own attribute discovery accepts.
    /// </summary>
    internal static IEnumerable<MethodInfo> GetToolMethods(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type toolType) =>
        toolType
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(m => m.GetCustomAttribute<McpServerToolAttribute>() is not null);

    /// <summary>Whether <paramref name="toolType"/> opted into the interaction tier.</summary>
    internal static bool RequiresInteraction(Type toolType) =>
        toolType.GetCustomAttribute<AgentInteractionToolsAttribute>() is not null;
}
