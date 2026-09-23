using Avalonia.Markup.Declarative;
using AvaloniaInternalCustomPublic;

[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: false)]
[assembly: GenerateMarkupExtensionsForAssembly(typeof(FixtureControl), generatePublicExtensions: true)]