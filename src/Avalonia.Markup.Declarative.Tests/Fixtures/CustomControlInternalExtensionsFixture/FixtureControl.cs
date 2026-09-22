using Avalonia;
using Avalonia.Controls;

namespace CustomControlInternalExtensionsFixture;

public sealed class FixtureControl : Control
{
    public static readonly StyledProperty<int> ValueProperty =
        AvaloniaProperty.Register<FixtureControl, int>(nameof(Value));

    public int Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}
