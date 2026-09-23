using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace AvaloniaInternalExtensionsFixture;

public sealed class FixtureMarker
{
    public static Button CreateButtonWithGeneratedWidth() => new Button().Width(120);
}
