using AvaloniaExtensionGenerator.Generators.SetterGenerators;

namespace AvaloniaExtensionGenerator.Generators.StyleSetterGenerators;

public class ValueOverloadsStyleSetterGenerator : SetterGeneratorBase
{
    public override string GetPropertySetterExtensionOverride(PropertyExtensionInfo info)
    {
        var extensionText = "";
        // overloads for primitive types like margin
        if (!info.ValueType.Module.ScopeName.StartsWith("System")
            && info.ValueType.IsValueType
            && info.ValueType.GetConstructors().Length > 1)
        {
            foreach (var constructor in info.ValueType.GetConstructors())
            {
                var ps = constructor.GetParameters();
                var argDefs = string.Join(", ", ps.Select(x => $"{x.ParameterType.FullName} {x.Name}"));
                var argVals = string.Join(", ", ps.Select(x => x.Name)); ;

                if (info.CanBeGenericConstraint)
                {
                    extensionText += $"public static Style<T> {info.ExtensionName}<T>(this Style<T> style, {argDefs})"
                                     + $" where T : {info.ControlTypeName}{Environment.NewLine}"
                                     + $"   => style._addSetter({info.ControlTypeName}.{info.PropertyName}Property, new {info.ValueTypeSource}({argVals}));";
                }
                else
                {
                    extensionText += $"public static Style<{info.ControlTypeName}> {info.ExtensionName}(this Style<{info.ControlTypeName}> style, {argDefs}){Environment.NewLine}" +
                                     $"   => style._addSetter({info.ControlTypeName}.{info.PropertyName}Property, new {info.ValueTypeSource}({argVals}));";
                }
            }
        }
        return extensionText;
    }
}