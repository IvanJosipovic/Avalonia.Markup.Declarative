#if DEBUG
using System.ComponentModel;
using Declarative.Avalonia.AgentTools;
using ModelContextProtocol.Server;

namespace AvaloniaMarkupSample;

/// <summary>
/// Stands in for an application service an agent tool would need — the sample's own state, which the
/// generic inspection tools know nothing about.
/// </summary>
public sealed class SampleSession
{
    public string ProjectName { get; set; } = "Untitled";

    public int EditCount { get; set; }
}

/// <summary>
/// Read-only host tools. Registered whenever the inspector runs, because reading app state changes
/// nothing.
/// </summary>
[McpServerToolType]
public sealed class SampleSessionTools(SampleSession session)
{
    [McpServerTool(Name = "sample_get_session", ReadOnly = true), Description(
        "Returns the sample's own session state — the project name and how many edits have been made. " +
        "Demonstrates a host tool reaching data the generic inspection tools cannot see.")]
    public string GetSession() =>
        $"Project '{session.ProjectName}', {session.EditCount} edit(s).";
}

/// <summary>
/// State-changing host tools, gated behind the same switch as the built-in interaction tier.
/// </summary>
[McpServerToolType]
[AgentInteractionTools]
public sealed class SampleSessionEditTools(SampleSession session)
{
    [McpServerTool(Name = "sample_rename_project", Destructive = true), Description(
        "Renames the sample's project and counts the change as an edit.")]
    public string RenameProject(
        [Description("The new project name.")] string name)
    {
        var previous = session.ProjectName;
        session.ProjectName = name;
        session.EditCount++;
        return $"Renamed '{previous}' to '{name}' ({session.EditCount} edit(s)).";
    }
}
#endif
