using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace AvaloniaPublicCustomInternal;

public sealed class FixtureMarker
{
    public static Button SetWidthWithGeneratedExtension() => new Button().Width(123);
}