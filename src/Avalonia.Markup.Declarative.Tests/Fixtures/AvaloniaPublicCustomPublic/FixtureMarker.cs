using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace AvaloniaPublicCustomPublic;

public sealed class FixtureMarker
{
    public static Button SetWidthWithGeneratedExtension() => new Button().Width(123);
}