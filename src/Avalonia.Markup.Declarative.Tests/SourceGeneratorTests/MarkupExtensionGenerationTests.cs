using System.Collections.Immutable;
using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Markup.Declarative.SourceGenerator.ExternalGenerators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Avalonia.Markup.Declarative.Tests.SourceGeneratorTests;

public class MarkupExtensionGenerationTests
{
    private const string FixtureNamespace = "MarkupExtensionGeneratorFixture";
    private static readonly ImmutableArray<MetadataReference> PlatformReferences = CreatePlatformReferences();

    [Fact]
    public void Avalonia_extensions_are_generated_internal_by_default_without_custom_control_extensions()
    {
        var result = RunGenerator(CreateCompilation("NoGenerationAttributes", CreateSource(string.Empty, """
            public static class Usage
            {
                public static Button SetWidth() => new Button().Width(120);
            }
            """)));

        AssertNoErrors(result.OutputCompilation);
        Assert.Contains(result.GeneratedSources, source =>
            source.Contains("internal static partial class Avalonia_Controls_Button_MarkupExtensions", StringComparison.Ordinal));
        Assert.DoesNotContain(result.GeneratedSources, source =>
            source.Contains("MarkupExtensionGeneratorFixture_FixtureControl_MarkupExtensions", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(true, true)]
    public void Avalonia_and_custom_control_options_generate_compilable_extensions(
        bool avaloniaExtensionsArePublic,
        bool customControlExtensionsArePublic)
    {
        var avaloniaAttribute = avaloniaExtensionsArePublic
            ? "[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]"
            : "[assembly: GenerateMarkupExtensionsForAvalonia]";
        var customAttribute = customControlExtensionsArePublic
            ? "[assembly: GenerateMarkupExtensionsForAssembly(typeof(MarkupExtensionGeneratorFixture.FixtureControl), generatePublicExtensions: true)]"
            : "[assembly: GenerateMarkupExtensionsForAssembly(typeof(MarkupExtensionGeneratorFixture.FixtureControl))]";
        var result = RunGenerator(CreateCompilation($"Accessibility_{avaloniaExtensionsArePublic}_{customControlExtensionsArePublic}", CreateSource($"{avaloniaAttribute}\n{customAttribute}", """
            public static class Usage
            {
                public static Button SetWidth() => new Button().Width(123);
                public static FixtureControl SetValue() => new FixtureControl().Value(42);
            }
            """)));

        AssertNoErrors(result.OutputCompilation);
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            $"{(avaloniaExtensionsArePublic ? "public" : "internal")} static partial class Avalonia_Controls_Button_MarkupExtensions",
            StringComparison.Ordinal));
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            $"{(customControlExtensionsArePublic ? "public" : "internal")} static partial class {FixtureNamespace}_FixtureControl_MarkupExtensions",
            StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Assembly_specific_attribute_generates_custom_control_extensions(bool generatePublicExtensions)
    {
        var attribute = generatePublicExtensions
            ? "[assembly: GenerateMarkupExtensionsForAssembly(typeof(MarkupExtensionGeneratorFixture.FixtureControl), generatePublicExtensions: true)]"
            : "[assembly: GenerateMarkupExtensionsForAssembly(typeof(MarkupExtensionGeneratorFixture.FixtureControl))]";
        var result = RunGenerator(CreateCompilation("AssemblySpecific_" + generatePublicExtensions, CreateSource(attribute, """
            public static class Usage
            {
                public static FixtureControl SetValue() => new FixtureControl().Value(42);
            }
            """)));

        AssertNoErrors(result.OutputCompilation);
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            $"{(generatePublicExtensions ? "public" : "internal")} static partial class {FixtureNamespace}_FixtureControl_MarkupExtensions",
            StringComparison.Ordinal));
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            "internal static partial class Avalonia_Controls_Button_MarkupExtensions",
            StringComparison.Ordinal));
    }

    [Fact]
    public void Public_generated_extensions_compile_and_are_consumed_by_a_referencing_compilation()
    {
        var librarySource = CreateSource(
            """
            [assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]
            [assembly: GenerateMarkupExtensionsForAssembly(typeof(MarkupExtensionGeneratorFixture.FixtureControl), generatePublicExtensions: true)]
            """,
            "");
        var libraryResult = RunGenerator(CreateCompilation("PublicExtensionsLibrary", librarySource));
        AssertNoErrors(libraryResult.OutputCompilation);

        using var libraryStream = new MemoryStream();
        var emitResult = libraryResult.OutputCompilation.Emit(libraryStream, cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(emitResult.Success, string.Join(Environment.NewLine, emitResult.Diagnostics));

        var referencedLibrary = MetadataReference.CreateFromImage(ImmutableArray.CreateRange(libraryStream.ToArray()));
        var consumerSource = """
            using Avalonia.Controls;
            using Avalonia.Markup.Declarative;
            using MarkupExtensionGeneratorFixture;

            public static class Consumer
            {
                public static Button SetWidth() => new Button().Width(240);
                public static FixtureControl SetValue() => new FixtureControl().Value(99);
            }
            """;
        var consumerResult = RunGenerator(CreateCompilation("PublicExtensionsConsumer", consumerSource, referencedLibrary));

        AssertNoErrors(consumerResult.OutputCompilation);
        Assert.DoesNotContain(consumerResult.GeneratedSources, source =>
            source.Contains("Avalonia_Controls_Button_MarkupExtensions", StringComparison.Ordinal));
        Assert.DoesNotContain(consumerResult.GeneratedSources, source =>
            source.Contains($"{FixtureNamespace}_FixtureControl_MarkupExtensions", StringComparison.Ordinal));
    }

    [Fact]
    public void Multiple_referenced_public_Avalonia_extension_providers_report_a_warning()
    {
        var firstProvider = CreatePublicAvaloniaExtensionsReference("FirstPublicExtensionsProvider");
        var secondProvider = CreatePublicAvaloniaExtensionsReference("SecondPublicExtensionsProvider");
        var consumer = RunGenerator(CreateCompilationWithReferences(
            "MultiplePublicExtensionsConsumer",
            CreateSource(string.Empty, """
                public static class ConsumerUsage
                {
                    public static Button SetWidth() => new Button().Width(120);
                }
                """),
            firstProvider,
            secondProvider));

        var warning = Assert.Single(consumer.Diagnostics.Where(static diagnostic =>
            diagnostic.Id == "AMDGEN001"));

        Assert.Equal(DiagnosticSeverity.Warning, warning.Severity);
        Assert.Contains("Avalonia.Controls.Button", warning.GetMessage(), StringComparison.Ordinal);
        Assert.Contains("FirstPublicExtensionsProvider", warning.GetMessage(), StringComparison.Ordinal);
        Assert.Contains("SecondPublicExtensionsProvider", warning.GetMessage(), StringComparison.Ordinal);
        Assert.DoesNotContain(consumer.GeneratedSources, static source =>
            source.Contains("Avalonia_Controls_Button_MarkupExtensions", StringComparison.Ordinal));
        Assert.Contains(
            consumer.OutputCompilation.GetDiagnostics(TestContext.Current.CancellationToken),
            static diagnostic => diagnostic.Id == "CS0121");
    }

    [Fact]
    public void Single_referenced_public_Avalonia_extension_provider_does_not_report_a_warning()
    {
        var provider = CreatePublicAvaloniaExtensionsReference("SinglePublicExtensionsProvider");
        var consumer = RunGenerator(CreateCompilationWithReferences(
            "SinglePublicExtensionsConsumer",
            CreateSource(string.Empty, ""),
            provider));

        Assert.DoesNotContain(consumer.Diagnostics, static diagnostic => diagnostic.Id == "AMDGEN001");
    }

    [Fact]
    public void Same_named_handwritten_extension_classes_do_not_report_a_warning()
    {
        const string handwrittenExtensions = """
            using Avalonia.Controls;

            namespace Avalonia.Markup.Declarative
            {
                public static class Avalonia_Controls_Button_MarkupExtensions
                {
                    public static Button Width(this Button button, double width) => button;
                }
            }
            """;
        var firstProvider = EmitReference(CreateCompilation("HandwrittenProviderOne", handwrittenExtensions));
        var secondProvider = EmitReference(CreateCompilation("HandwrittenProviderTwo", handwrittenExtensions));
        var consumer = RunGenerator(CreateCompilationWithReferences(
            "HandwrittenExtensionsConsumer",
            CreateSource(string.Empty, ""),
            firstProvider,
            secondProvider));

        Assert.DoesNotContain(consumer.Diagnostics, static diagnostic => diagnostic.Id == "AMDGEN001");
    }

    [Theory]
    [InlineData(false, true)]
    [InlineData(true, false)]
    public void Options_for_the_same_Avalonia_assembly_merge_to_public(
        bool avaloniaAttributeIsPublic,
        bool assemblyAttributeIsPublic)
    {
        var avaloniaAttribute = avaloniaAttributeIsPublic
            ? "[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]"
            : "[assembly: GenerateMarkupExtensionsForAvalonia]";
        var assemblyAttribute = assemblyAttributeIsPublic
            ? "[assembly: GenerateMarkupExtensionsForAssembly(typeof(Button), generatePublicExtensions: true)]"
            : "[assembly: GenerateMarkupExtensionsForAssembly(typeof(Button))]";
        var result = RunGenerator(CreateCompilation(
            $"MergeOptions_{avaloniaAttributeIsPublic}_{assemblyAttributeIsPublic}",
            CreateSource($"{avaloniaAttribute}\n{assemblyAttribute}", """
                public static class Usage
                {
                    public static Button SetWidth() => new Button().Width(123);
                }
                """)));

        AssertNoErrors(result.OutputCompilation);
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            "public static partial class Avalonia_Controls_Button_MarkupExtensions",
            StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Assembly_attribute_can_target_a_control_from_a_referenced_assembly(bool generatePublicExtensions)
    {
        var controlLibrary = CreateCompilation("ReferencedControls", CreateSource(string.Empty, ""));
        var controlLibraryReference = EmitReference(controlLibrary);
        var generatePublicOption = generatePublicExtensions ? ", generatePublicExtensions: true" : string.Empty;
        var consumerSource = $$"""
            using Avalonia.Markup.Declarative;
            using MarkupExtensionGeneratorFixture;

            [assembly: GenerateMarkupExtensionsForAssembly(typeof(FixtureControl){{generatePublicOption}})]

            public static class Usage
            {
                public static FixtureControl SetValue() => new FixtureControl().Value(42);
            }
            """;
        var result = RunGenerator(CreateCompilation("ExternalAssemblyTarget_" + generatePublicExtensions, consumerSource, controlLibraryReference));

        AssertNoErrors(result.OutputCompilation);
        Assert.Contains(result.GeneratedSources, source => source.Contains(
            $"{(generatePublicExtensions ? "public" : "internal")} static partial class {FixtureNamespace}_FixtureControl_MarkupExtensions",
            StringComparison.Ordinal));
    }

    [Fact]
    public void Referenced_internal_extensions_do_not_suppress_local_generation()
    {
        var internalLibrary = RunGenerator(CreateCompilation(
            "InternalAvaloniaExtensionsLibrary",
            CreateSource("[assembly: GenerateMarkupExtensionsForAvalonia]", "")));
        AssertNoErrors(internalLibrary.OutputCompilation);
        var internalLibraryReference = EmitReference(internalLibrary.OutputCompilation);
        var consumerSource = CreateSource(string.Empty, """
            public static class Usage
            {
                public static Button SetWidth() => new Button().Width(240);
            }
            """);
        var consumer = RunGenerator(CreateCompilation("InternalExtensionsConsumer", consumerSource, internalLibraryReference));

        AssertNoErrors(consumer.OutputCompilation);
        Assert.Contains(consumer.GeneratedSources, source => source.Contains(
            "internal static partial class Avalonia_Controls_Button_MarkupExtensions",
            StringComparison.Ordinal));
    }

    [Fact]
    public void Public_generated_extensions_disable_missing_documentation_warnings()
    {
        var source = CreateSource(
            "[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]",
            "");
        var compilation = CreateCompilation(
            "DocumentedPublicExtensions",
            source,
            compilationOptions: new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                generalDiagnosticOption: ReportDiagnostic.Error,
                nullableContextOptions: NullableContextOptions.Enable));
        var result = RunGenerator(compilation);

        using var assemblyStream = new MemoryStream();
        using var documentationStream = new MemoryStream();
        var emitResult = result.OutputCompilation.Emit(
            assemblyStream,
            xmlDocumentationStream: documentationStream,
            cancellationToken: TestContext.Current.CancellationToken);

        Assert.Contains(result.GeneratedSources, generated => generated.Contains("#pragma warning disable CS1591", StringComparison.Ordinal));
        Assert.True(emitResult.Success, string.Join(Environment.NewLine, emitResult.Diagnostics));
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

    private static GeneratorResult RunGenerator(CSharpCompilation compilation)
    {
        var parseOptions = new CSharpParseOptions(LanguageVersion.Preview);
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            [new ExternalAssemblyExtensionsGenerator().AsSourceGenerator()],
            parseOptions: parseOptions);
        driver = driver.RunGeneratorsAndUpdateCompilation(
            compilation,
            out var outputCompilation,
            out var driverDiagnostics,
            TestContext.Current.CancellationToken);
        var runResult = driver.GetRunResult();
        var generatedSources = runResult.Results
            .SelectMany(static result => result.GeneratedSources)
            .Select(static generated => generated.SourceText.ToString())
            .ToImmutableArray();

        Assert.Empty(driverDiagnostics.Where(static diagnostic => diagnostic.Severity == DiagnosticSeverity.Error));
        Assert.Empty(runResult.Diagnostics.Where(static diagnostic => diagnostic.Severity == DiagnosticSeverity.Error));
        return new GeneratorResult(
            (CSharpCompilation)outputCompilation,
            generatedSources,
            driverDiagnostics);
    }

    private static PortableExecutableReference CreatePublicAvaloniaExtensionsReference(string assemblyName)
    {
        var libraryResult = RunGenerator(CreateCompilation(
            assemblyName,
            CreateSource("[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]", "")));
        AssertNoErrors(libraryResult.OutputCompilation);
        return EmitReference(libraryResult.OutputCompilation);
    }

    private static PortableExecutableReference EmitReference(CSharpCompilation compilation)
    {
        using var assemblyStream = new MemoryStream();
        var emitResult = compilation.Emit(assemblyStream, cancellationToken: TestContext.Current.CancellationToken);
        Assert.True(emitResult.Success, string.Join(Environment.NewLine, emitResult.Diagnostics));
        return MetadataReference.CreateFromImage(ImmutableArray.CreateRange(assemblyStream.ToArray()));
    }

    private static CSharpCompilation CreateCompilation(
        string assemblyName,
        string source,
        MetadataReference? additionalReference = null,
        CSharpCompilationOptions? compilationOptions = null)
    {
        var references = additionalReference is null
            ? PlatformReferences
            : PlatformReferences.Add(additionalReference);

        return CSharpCompilation.Create(
            assemblyName,
            [CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview))],
            references,
            compilationOptions ?? new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Enable));
    }

    private static CSharpCompilation CreateCompilationWithReferences(
        string assemblyName,
        string source,
        params MetadataReference[] additionalReferences) =>
        CSharpCompilation.Create(
            assemblyName,
            [CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview))],
            PlatformReferences.AddRange(additionalReferences),
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Enable));

    private static ImmutableArray<MetadataReference> CreatePlatformReferences()
    {
        var trustedAssemblies = (string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")
            ?? throw new InvalidOperationException("The runtime did not provide trusted platform assemblies.");

        var paths = trustedAssemblies.Split(Path.PathSeparator)
            .Append(typeof(Control).Assembly.Location)
            .Append(typeof(AvaloniaProperty).Assembly.Location)
            .Append(typeof(GenerateMarkupExtensionsForAvaloniaAttribute).Assembly.Location)
            .Where(path => !StringComparer.OrdinalIgnoreCase.Equals(path, typeof(MarkupExtensionGenerationTests).Assembly.Location))
            .Where(static path => !string.IsNullOrWhiteSpace(path))
            .Distinct(StringComparer.OrdinalIgnoreCase);

        return [.. paths.Select(static path => MetadataReference.CreateFromFile(path))];
    }

    private static string CreateSource(string assemblyAttributes, string usage) => $$"""
        using Avalonia;
        using Avalonia.Controls;
        using Avalonia.Markup.Declarative;

        {{assemblyAttributes}}

        namespace {{FixtureNamespace}}
        {
            /// <summary>A control used by markup extension generator tests.</summary>
            public class FixtureControl : Control
            {
                /// <summary>The fixture control value property.</summary>
                public static readonly StyledProperty<int> ValueProperty =
                    AvaloniaProperty.Register<FixtureControl, int>(nameof(Value));

                /// <summary>The fixture control value.</summary>
                public int Value
                {
                    get => GetValue(ValueProperty);
                    set => SetValue(ValueProperty, value);
                }
            }
        }

        namespace {{FixtureNamespace}}
        {
        {{usage}}
        }
        """;

    private static void AssertNoErrors(CSharpCompilation compilation)
    {
        var errors = compilation.GetDiagnostics().Where(static diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.Empty(errors);
    }

    private sealed record GeneratorResult(
        CSharpCompilation OutputCompilation,
        ImmutableArray<string> GeneratedSources,
        ImmutableArray<Diagnostic> Diagnostics);
}
