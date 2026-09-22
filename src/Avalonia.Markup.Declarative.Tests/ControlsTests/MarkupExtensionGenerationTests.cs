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
        var extension = LoadFixture("CustomControlInternalExtensionsFixture").GetType(
            "Avalonia.Markup.Declarative.CustomControlInternalExtensionsFixture_FixtureControl_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.False(extension!.IsPublic);
    }

    [Fact]
    public void Custom_control_attribute_can_generate_public_extensions()
    {
        var extension = LoadFixture("CustomControlPublicExtensionsFixture").GetType(
            "Avalonia.Markup.Declarative.CustomControlPublicExtensionsFixture_FixtureControl_MarkupExtensions");

        Assert.NotNull(extension);
        Assert.True(extension!.IsPublic);
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
}
