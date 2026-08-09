using System.ComponentModel;
using ModelContextProtocol.Server;

namespace Declarative.Avalonia.AgentTools.Tests;

/// <summary>
/// Stands in for the application state a host would inject — the thing the generic inspection tools
/// cannot see, because to them the app's canvas is one opaque control.
/// </summary>
public sealed class HostAppState
{
    public string CurrentDocument { get; init; } = string.Empty;
}

/// <summary>
/// A read-only host tool type: available whenever the inspector runs, because reading the app's own
/// model changes nothing.
/// </summary>
[McpServerToolType]
public sealed class HostSceneTools
{
    private readonly HostAppState _state;

    public HostSceneTools(HostAppState state) => _state = state;

    [McpServerTool(Name = "host_describe_document", ReadOnly = true), Description(
        "Returns the document the app currently has open.")]
    public string DescribeDocument() => $"Document: {_state.CurrentDocument}";
}

/// <summary>
/// A state-changing host tool type, gated behind the same switch as the built-in interaction tier.
/// </summary>
[McpServerToolType]
[AgentInteractionTools]
public sealed class HostEditTools
{
    [McpServerTool(Name = "host_clear_document", Destructive = true), Description(
        "Clears the current document.")]
    public static string ClearDocument() => "cleared";
}
