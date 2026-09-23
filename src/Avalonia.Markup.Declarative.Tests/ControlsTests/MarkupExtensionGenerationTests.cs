using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using System.Reflection;

namespace Avalonia.Markup.Declarative.Tests.ControlsTests;

public class MarkupExtensionGenerationTests
{
    [Fact]
    public void Without_generation_attributes_Avalonia_defaults_are_internal_and_custom_extensions_are_absent()
    {
        var assembly = LoadFixture("NoMarkupExtensionsFixture");
        var avaloniaExtension = assembly.GetType("Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");

        Assert.NotNull(avaloniaExtension);
        Assert.False(avaloniaExtension!.IsPublic);
        Assert.Null(assembly.GetType(
            "Avalonia.Markup.Declarative.NoMarkupExtensionsFixture_FixtureControl_MarkupExtensions"));
    }

    [Fact]
    public void Avalonia_attribute_defaults_to_internal_extensions()
    {
        var assembly = LoadFixture("AvaloniaInternalExtensionsFixture");
        var extension = assembly.GetType("Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.False(extension!.IsPublic);

        var button = InvokeFixtureMethod(assembly, "AvaloniaInternalExtensionsFixture.FixtureMarker", "CreateButtonWithGeneratedWidth");
        Assert.Equal(120, Assert.IsType<Button>(button).Width);
    }

    [Fact]
    public void Avalonia_attribute_can_generate_public_extensions()
    {
        var extension = LoadFixture("PublicAvaloniaExtensionsFixture").GetType(
            "Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.True(extension!.IsPublic);
    }

    [Fact]
    public void Custom_control_attribute_defaults_to_internal_extensions()
    {
        var assembly = LoadFixture("CustomControlInternalExtensionsFixture");
        var extension = assembly.GetType(
            "Avalonia.Markup.Declarative.CustomControlInternalExtensionsFixture_FixtureControl_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.False(extension!.IsPublic);

        var control = InvokeFixtureMethod(assembly, "CustomControlInternalExtensionsFixture.FixtureControl", "CreateWithGeneratedValue");
        Assert.Equal(42, control!.GetType().GetProperty("Value")!.GetValue(control));
    }

    [Fact]
    public void Custom_control_attribute_can_generate_public_extensions()
    {
        var assembly = LoadFixture("CustomControlPublicExtensionsFixture");
        var extension = assembly.GetType(
            "Avalonia.Markup.Declarative.CustomControlPublicExtensionsFixture_FixtureControl_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.True(extension!.IsPublic);

        var control = InvokeFixtureMethod(assembly, "CustomControlPublicExtensionsFixture.FixtureControl", "CreateWithGeneratedValue");
        Assert.Equal(42, control!.GetType().GetProperty("Value")!.GetValue(control));
    }

    [Fact]
    public void Referenced_public_Avalonia_extensions_are_not_generated_again()
    {
        var referencedExtension = LoadFixture("PublicAvaloniaExtensionsFixture").GetType(
            "Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");
        var localExtension = LoadFixture("AvaloniaDeduplicationFixture").GetType(
            "Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");

        Assert.NotNull(referencedExtension);
        Assert.True(referencedExtension!.IsPublic);
        Assert.Null(localExtension);

        var button = InvokeFixtureMethod(LoadFixture("AvaloniaDeduplicationFixture"), "AvaloniaDeduplicationFixture.FixtureMarker", "CreateButtonWithReferencedWidth");
        Assert.Equal(240, Assert.IsType<Button>(button).Width);
    }

    [Fact]
    public void Public_custom_control_extension_method_is_usable_from_a_dependent_assembly()
    {
        var extension = LoadFixture("CustomControlPublicExtensionsFixture").GetType(
            "Avalonia.Markup.Declarative.CustomControlPublicExtensionsFixture_FixtureControl_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.True(extension!.IsPublic);
        Assert.Contains(extension.GetMethods(BindingFlags.Public | BindingFlags.Static), method => method.Name == "Value");

        var control = InvokeFixtureMethod(
            LoadFixture("CustomControlDependentFixture"),
            "CustomControlDependentFixture.FixtureMarker",
            "CreateWithReferencedValue");
        Assert.Equal(99, control!.GetType().GetProperty("Value")!.GetValue(control));
    }

    [Theory]
    [InlineData("AvaloniaInternalCustomInternal", false, false)]
    [InlineData("AvaloniaInternalCustomPublic", false, true)]
    [InlineData("AvaloniaPublicCustomInternal", true, false)]
    [InlineData("AvaloniaPublicCustomPublic", true, true)]
    public void Both_attributes_generate_usable_extensions_with_requested_accessibility(
        string fixtureName,
        bool avaloniaExtensionsArePublic,
        bool customExtensionsArePublic)
    {
        var assembly = LoadFixture(fixtureName);
        var avaloniaExtensions = assembly.GetType("Avalonia.Markup.Declarative.Avalonia_Controls_Button_MarkupExtensions");
        var customExtensions = assembly.GetType(
            $"Avalonia.Markup.Declarative.{fixtureName}_FixtureControl_MarkupExtensions");

        Assert.NotNull(avaloniaExtensions);
        Assert.Equal(avaloniaExtensionsArePublic, avaloniaExtensions!.IsPublic);
        Assert.NotNull(customExtensions);
        Assert.Equal(customExtensionsArePublic, customExtensions!.IsPublic);

        var button = InvokeFixtureMethod(assembly, $"{fixtureName}.FixtureMarker", "SetWidthWithGeneratedExtension");
        Assert.Equal(123, Assert.IsType<Button>(button).Width);

        var control = InvokeFixtureMethod(assembly, $"{fixtureName}.FixtureControl", "SetValueWithGeneratedExtension");
        Assert.Equal(42, control!.GetType().GetProperty("Value")!.GetValue(control));
    }

    [Fact]
    public void Generation_attribute_constructors_preserve_options()
    {
        var constructor = typeof(GenerateMarkupExtensionsForAssemblyAttribute).GetConstructor([typeof(Type)]);
        var internalAttribute = new GenerateMarkupExtensionsForAssemblyAttribute(typeof(Control));
        var publicAttribute = new GenerateMarkupExtensionsForAssemblyAttribute(typeof(Control), generatePublicExtensions: true);
        var avaloniaAttribute = new GenerateMarkupExtensionsForAvaloniaAttribute(generatePublicExtensions: true);

        Assert.NotNull(constructor);
        Assert.False(internalAttribute.GeneratePublicExtensions);
        Assert.True(publicAttribute.GeneratePublicExtensions);
        Assert.True(avaloniaAttribute.GeneratePublicExtensions);
    }

    private static Assembly LoadFixture(string assemblyName) =>
        Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "Fixtures", $"{assemblyName}.dll"));

    private static object? InvokeFixtureMethod(Assembly assembly, string typeName, string methodName) =>
        assembly.GetType(typeName)!.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static)!.Invoke(null, null);
}
