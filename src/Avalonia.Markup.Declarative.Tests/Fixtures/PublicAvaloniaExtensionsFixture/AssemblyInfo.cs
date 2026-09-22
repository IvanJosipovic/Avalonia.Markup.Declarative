using Avalonia.Markup.Declarative;
using PublicAvaloniaExtensionsFixture;

[assembly: GenerateMarkupExtensionsForAvalonia(true)]
[assembly: GenerateMarkupExtensionsForAssembly(typeof(PublicFixtureControl), generatePublicExtensions: true)]
