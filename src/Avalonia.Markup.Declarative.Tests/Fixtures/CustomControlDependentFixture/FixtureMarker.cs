using Avalonia.Markup.Declarative;
using CustomControlPublicExtensionsFixture;

namespace CustomControlDependentFixture;

public sealed class FixtureMarker
{
    public static FixtureControl CreateWithReferencedValue() =>
        Avalonia.Markup.Declarative.CustomControlPublicExtensionsFixture_FixtureControl_MarkupExtensions.Value(new FixtureControl(), 99);
}
