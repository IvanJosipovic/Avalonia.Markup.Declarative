using System;

namespace Avalonia.Markup.Declarative;

/// <summary>
/// Indicates that markup extensions should be generated for types in this assembly.
/// </summary>
/// <param name="anchorType">The type used as the anchor for generating markup extensions.</param>
/// <param name="generatePublicExtensions">A value indicating whether generated extension members are declared as public.</param>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class GenerateMarkupExtensionsForAssemblyAttribute(Type anchorType, bool generatePublicExtensions = false) : Attribute
{
    /// <summary>
    /// Gets the type used as the anchor.
    /// </summary>
    public Type AnchorType { get; } = anchorType;

    /// <summary>
    /// Gets a value indicating whether generated extension members are declared as public.
    /// </summary>
    public bool GeneratePublicExtensions { get; } = generatePublicExtensions;
}
