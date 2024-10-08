using System.Reflection;

namespace AvaloniaExtensionGenerator.Generators.SetterGenerators;

public abstract class SetterGeneratorBase : IMemberExtensionGenerator<FieldInfo>
{
    public string? GetExtension(FieldInfo field, out IEnumerable<string> usedNamespaces)
    {
        var namespaces = new HashSet<string>();
        var info = new PropertyExtensionInfo(field, t => GetTypeDeclarationSourceCode(t, namespaces));
        if (!string.IsNullOrWhiteSpace(info.ControlType.Namespace))
            namespaces.Add(info.ControlType.Namespace);

        usedNamespaces = namespaces;

        var prefix = "";
        if (info.IsObsolete)
            prefix = $"\t[Obsolete(\"{info.ObsoleteMessage}\")]{Environment.NewLine}";

        return prefix + GetPropertySetterExtensionOverride(info);
    }

    public abstract string GetPropertySetterExtensionOverride(PropertyExtensionInfo info);

    public string GetTypeDeclarationSourceCode(Type valueType, HashSet<string> namespaces)
    {
        if (!string.IsNullOrWhiteSpace(valueType.Namespace))
            namespaces.Add(valueType.Namespace);

        var result = valueType.Name;

        if (valueType.IsGenericType)
        {
            result = result.Split('`')[0];
            
            var genericArguments = valueType
                .GetGenericArguments()
                .Select(x =>
                {
                    var arg = GetTypeDeclarationSourceCode(x, namespaces);
                    //if (!result.StartsWith("Nullable") && !IsNullable(x))
                    //    arg += "?";
                    return arg;
                });

            var args = string.Join(",", genericArguments);
            result += $"<{args}>";
        }

        var hasConflictingNamespace = namespaces.Any(x => x.EndsWith(result));

        //todo: handle cases when Type is equal namespace name, i.e.
        //Avalonia.Controls.Calendar
        //ContextMenu
        //Animation
        //Dock

        if (!string.IsNullOrWhiteSpace(valueType.Namespace))
        {
            result = valueType.Namespace + "." + result;
        }

        return result;
    }
}