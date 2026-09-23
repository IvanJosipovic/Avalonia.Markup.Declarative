using Avalonia.Markup.Declarative;
using AvaloniaPublicCustomInternal;

[assembly: GenerateMarkupExtensionsForAvalonia(generatePublicExtensions: true)]
[assembly: GenerateMarkupExtensionsForAssembly(typeof(FixtureControl), generatePublicExtensions: false)]