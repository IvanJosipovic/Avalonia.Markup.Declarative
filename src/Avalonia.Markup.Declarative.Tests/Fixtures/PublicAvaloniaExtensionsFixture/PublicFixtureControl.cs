using Avalonia;
using Avalonia.Controls;

namespace PublicAvaloniaExtensionsFixture;

/// <summary>A control used to verify public generated extensions from a referenced assembly.</summary>
public sealed class PublicFixtureControl : Control
{
    /// <summary>Defines the <see cref="Value"/> property.</summary>
    public static readonly StyledProperty<int> ValueProperty =
        AvaloniaProperty.Register<PublicFixtureControl, int>(nameof(Value));

    /// <summary>Gets or sets the test value.</summary>
    public int Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}
