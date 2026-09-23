using Avalonia;
using Avalonia.Controls;

namespace AvaloniaInternalCustomPublic;

public sealed class FixtureControl : Control
{
    public static readonly StyledProperty<int> ValueProperty =
        AvaloniaProperty.Register<FixtureControl, int>(nameof(Value));

    public int Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static FixtureControl SetValueWithGeneratedExtension() =>
        Avalonia.Markup.Declarative.AvaloniaInternalCustomPublic_FixtureControl_MarkupExtensions.Value(new FixtureControl(), 42);
}