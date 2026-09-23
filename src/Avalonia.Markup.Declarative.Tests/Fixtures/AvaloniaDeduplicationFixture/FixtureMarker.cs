using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace AvaloniaDeduplicationFixture;

public sealed class FixtureMarker
{
    public static Button CreateButtonWithReferencedWidth() => new Button().Width(240);

}
