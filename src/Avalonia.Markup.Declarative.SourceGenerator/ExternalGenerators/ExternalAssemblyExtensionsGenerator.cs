using System.Collections.Immutable;
using System.Text;
using Avalonia.Markup.Declarative.SourceGenerator.ExtensionInfos;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Avalonia.Markup.Declarative.SourceGenerator.ExternalGenerators;

[Generator]
public sealed class ExternalAssemblyExtensionsGenerator : IIncrementalGenerator
{
    private static readonly DiagnosticDescriptor DuplicatePublicAvaloniaExtensions = new(
        id: "AMDGEN001",
        title: "Duplicate public Avalonia markup extensions",
        messageFormat: "Multiple referenced assemblies provide public Avalonia markup extensions for '{0}' ({1} conflicting Avalonia types total): {2}. Keep public Avalonia extensions in one library in the dependency graph.",
        category: "Avalonia.Markup.Declarative",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Multiple referenced libraries publish generated extension methods for the same Avalonia type, which can make extension calls ambiguous.");

    private static readonly ExternalGeneratorHost GeneratorHost = new();

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var generationTargets = context.CompilationProvider
            .SelectMany(static (compilation, _) => GetGenerationTargets(compilation))
            .WithComparer(ExternalGenerationTargetComparer.Instance);

        context.RegisterSourceOutput(context.CompilationProvider, static (spc, compilation) =>
        {
            foreach (var diagnostic in GetDuplicatePublicAvaloniaExtensionDiagnostics(compilation))
            {
                spc.ReportDiagnostic(diagnostic);
            }
        });

        context.RegisterSourceOutput(generationTargets, static (spc, target) =>
        {
            try
            {
                var code = GeneratorHost.GenerateExtensions(target.TypeSymbol, target.GeneratePublicExtensions);
                if (string.IsNullOrWhiteSpace(code))
                {
                    return;
                }

                spc.AddSource(target.HintName, SourceText.From(code!, Encoding.UTF8));
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        });
    }

    private static ImmutableArray<ExternalGenerationTarget> GetGenerationTargets(Compilation compilation)
    {
        return [..
            SymbolUtilities.GetTargetAssemblies(compilation)
                .SelectMany(targetAssembly => SymbolUtilities.GetPublicClasses(targetAssembly.Assembly.GlobalNamespace)
                    .Where(static publicClass => publicClass.IsOrInheritsFrom("Avalonia.AvaloniaObject"))
                    .Where(publicClass => !HasPublicExtensionFromReferencedAssembly(compilation, publicClass))
                    .Select(publicClass => ExternalGenerationTarget.Create(publicClass, targetAssembly.GeneratePublicExtensions)))
                .OrderBy(static target => target.HintName, StringComparer.Ordinal)
        ];
    }

    private static IEnumerable<Diagnostic> GetDuplicatePublicAvaloniaExtensionDiagnostics(Compilation compilation)
    {
        var conflictsByProviderSet = new Dictionary<string, List<string>>(StringComparer.Ordinal);
        var referencedAssemblies = compilation.References
            .Select(compilation.GetAssemblyOrModuleSymbol)
            .OfType<IAssemblySymbol>()
            .ToArray();

        foreach (var targetAssembly in SymbolUtilities.GetTargetAssemblies(compilation))
        {
            foreach (var publicClass in SymbolUtilities.GetPublicClasses(targetAssembly.Assembly.GlobalNamespace)
                         .Where(static type => type.IsOrInheritsFrom("Avalonia.AvaloniaObject")))
            {
                var extensionTypeName = $"Avalonia.Markup.Declarative.{SymbolUtilities.BuildExtensionClassName(publicClass)}";
                var providers = referencedAssemblies
                    .Select(assembly => (Assembly: assembly, ExtensionType: assembly.GetTypeByMetadataName(extensionTypeName)))
                    .Where(static provider => provider.ExtensionType is
                    {
                        DeclaredAccessibility: Accessibility.Public
                    } extensionType && IsGeneratedExtensionType(extensionType))
                    .Select(static provider => provider.Assembly.Name)
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(static assemblyName => assemblyName, StringComparer.Ordinal)
                    .ToArray();

                if (providers.Length < 2)
                {
                    continue;
                }

                var providerSet = string.Join("\u001f", providers);
                if (!conflictsByProviderSet.TryGetValue(providerSet, out var conflictingTypes))
                {
                    conflictingTypes = [];
                    conflictsByProviderSet.Add(providerSet, conflictingTypes);
                }

                conflictingTypes.Add(publicClass.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat));
            }
        }

        foreach (var conflict in conflictsByProviderSet)
        {
            conflict.Value.Sort(StringComparer.Ordinal);
            var exampleType = conflict.Value.FirstOrDefault(static type => type == "Avalonia.Controls.Button")
                ?? conflict.Value[0];
            yield return Diagnostic.Create(
                DuplicatePublicAvaloniaExtensions,
                Location.None,
                exampleType,
                conflict.Value.Count,
                string.Join(", ", conflict.Key.Split(new[] { '\u001f' })));
        }
    }

    private static bool IsGeneratedExtensionType(INamedTypeSymbol type) =>
        type.GetAttributes().Any(static attribute =>
            attribute.AttributeClass?.ToDisplayString() == "System.CodeDom.Compiler.GeneratedCodeAttribute" &&
            attribute.ConstructorArguments.Length > 0 &&
            attribute.ConstructorArguments[0].Value is string generatorName &&
            generatorName == "Avalonia.Markup.Declarative.SourceGenerator");

    private static bool HasPublicExtensionFromReferencedAssembly(
        Compilation compilation,
        INamedTypeSymbol publicClass)
    {
        var extensionTypes = compilation.GetTypesByMetadataName(
            $"Avalonia.Markup.Declarative.{SymbolUtilities.BuildExtensionClassName(publicClass)}");

        return extensionTypes.Any(extensionType =>
            extensionType.DeclaredAccessibility == Accessibility.Public &&
            !SymbolEqualityComparer.Default.Equals(extensionType.ContainingAssembly, compilation.Assembly));
    }

    private readonly struct ExternalGenerationTarget
    {
        public ExternalGenerationTarget(INamedTypeSymbol typeSymbol, string hintName, string signature, bool generatePublicExtensions)
        {
            TypeSymbol = typeSymbol;
            HintName = hintName;
            Signature = signature;
            GeneratePublicExtensions = generatePublicExtensions;
        }

        public INamedTypeSymbol TypeSymbol { get; }

        public string HintName { get; }

        public string Signature { get; }

        public bool GeneratePublicExtensions { get; }

        public static ExternalGenerationTarget Create(INamedTypeSymbol typeSymbol, bool generatePublicExtensions)
        {
            var hintName = $"External_{SymbolUtilities.RemoveIllegalFileNameCharacters(typeSymbol.ToDisplayString())}.g.cs";
            var signature = CreateSignature(typeSymbol, generatePublicExtensions);

            return new ExternalGenerationTarget(typeSymbol, hintName, signature, generatePublicExtensions);
        }
    }

    private sealed class ExternalGenerationTargetComparer : IEqualityComparer<ExternalGenerationTarget>
    {
        internal static readonly ExternalGenerationTargetComparer Instance = new();

        public bool Equals(ExternalGenerationTarget x, ExternalGenerationTarget y) =>
            StringComparer.Ordinal.Equals(x.HintName, y.HintName) &&
            StringComparer.Ordinal.Equals(x.Signature, y.Signature);

        public int GetHashCode(ExternalGenerationTarget obj)
        {
            unchecked
            {
                return (StringComparer.Ordinal.GetHashCode(obj.HintName) * 397) ^
                    StringComparer.Ordinal.GetHashCode(obj.Signature);
            }
        }
    }

    private static string CreateSignature(INamedTypeSymbol typeSymbol, bool generatePublicExtensions)
    {
        var signature = new StringBuilder(1024);
        AppendSignaturePart(signature, generatePublicExtensions ? "public" : "internal");
        AppendSignaturePart(signature, typeSymbol.ContainingAssembly.Identity.ToString());
        AppendSignaturePart(signature, typeSymbol.GetFullTypeName());
        AppendSignaturePart(signature, SymbolUtilities.BuildExtensionClassName(typeSymbol));
        AppendSignaturePart(signature, typeSymbol.IsSealed ? "sealed" : "open");

        foreach (var info in ExternalGeneratorHost.GetPropertyInfos(typeSymbol)
                     .OrderBy(static x => x.ExtensionName, StringComparer.Ordinal)
                     .ThenBy(static x => x.FieldSymbol.Name, StringComparer.Ordinal))
        {
            AppendPropertyInfoSignature(signature, "property", info);
        }

        foreach (var info in ExternalGeneratorHost.GetAttachedPropertyInfos(typeSymbol)
                     .OrderBy(static x => x.ExtensionName, StringComparer.Ordinal)
                     .ThenBy(static x => x.FieldSymbol.Name, StringComparer.Ordinal))
        {
            AppendPropertyInfoSignature(signature, "attached", info);
            AppendSignaturePart(signature, info.AttachedPropertyHostTypeName);
        }

        foreach (var info in ExternalGeneratorHost.GetEventInfos(typeSymbol)
                     .OrderBy(static x => x.EventName, StringComparer.Ordinal))
        {
            AppendEventInfoSignature(signature, info);
        }

        foreach (var info in ExternalGeneratorHost.GetStyleInfos(typeSymbol)
                     .OrderBy(static x => x.ExtensionName, StringComparer.Ordinal)
                     .ThenBy(static x => x.FieldSymbol.Name, StringComparer.Ordinal))
        {
            AppendPropertyInfoSignature(signature, "style", info);
        }

        return signature.ToString();
    }

    private static void AppendPropertyInfoSignature(StringBuilder signature, string groupName, PropertyExtensionInfo info)
    {
        AppendSignaturePart(signature, groupName);
        AppendSignaturePart(signature, info.ControlTypeName);
        AppendSignaturePart(signature, info.ExtensionName);
        AppendSignaturePart(signature, info.MemberName);
        AppendSignaturePart(signature, info.XmlDoc);
        AppendSignaturePart(signature, info.ValueTypeSource);
        AppendSignaturePart(signature, info.ReturnType);
        AppendSignaturePart(signature, info.GenericConstraint);
        AppendSignaturePart(signature, info.StyleGenericConstraint);
        AppendSignaturePart(signature, info.GenericArg);
        AppendSignaturePart(signature, info.FieldSymbol.Name);
        AppendValueTypeSignature(signature, info.ValueType);
    }

    private static void AppendEventInfoSignature(StringBuilder signature, EventExtensionInfo info)
    {
        AppendSignaturePart(signature, "event");
        AppendSignaturePart(signature, info.ControlTypeName);
        AppendSignaturePart(signature, info.EventName);
        AppendSignaturePart(signature, info.EventHandler);
        AppendSignaturePart(signature, info.XmlDoc);
        AppendSignaturePart(signature, info.ReturnType);
        AppendSignaturePart(signature, info.GenericConstraint);
        AppendSignaturePart(signature, info.GenericArg);
        AppendSignaturePart(signature, info.IsRoutedEvent ? "routed" : "plain");
        AppendSignaturePart(signature, info.SupportsAddHandler ? "addhandler" : "subscription");
        AppendSignaturePart(signature, info.IsObsolete ? "obsolete" : "active");
        AppendSignaturePart(signature, info.ReturnsVoid ? "void" : "nonvoid");

        foreach (var parameterType in info.EventParameterTypes)
        {
            AppendSignaturePart(signature, parameterType);
        }
    }

    private static void AppendValueTypeSignature(StringBuilder signature, ITypeSymbol valueType)
    {
        AppendSignaturePart(signature, valueType.GetFullTypeName());

        if (!valueType.IsValueType ||
            valueType.ContainingNamespace.ToDisplayString().StartsWith("System", StringComparison.Ordinal))
        {
            return;
        }

        foreach (var constructor in valueType.GetMembers()
                     .OfType<IMethodSymbol>()
                     .Where(static x => x.MethodKind == MethodKind.Constructor && x.Parameters.Length > 0)
                     .OrderBy(static x => x.ToDisplayString(), StringComparer.Ordinal))
        {
            AppendSignaturePart(signature, "ctor");

            foreach (var parameter in constructor.Parameters)
            {
                AppendSignaturePart(signature, parameter.Type.GetFullTypeName());
                AppendSignaturePart(signature, parameter.Name);
            }
        }
    }

    private static void AppendSignaturePart(StringBuilder signature, string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            signature.Append(value);
        }

        signature.Append('\u001F');
    }
}
