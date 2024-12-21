﻿using AvaloniaExtensionGenerator.ExtensionInfos;
using Microsoft.CodeAnalysis;

namespace AvaloniaExtensionGenerator.Generators.SetterGenerators;

public class CommonPropertyExpressionBindingSetterExtension : ExtensionGeneratorBase<PropertyExtensionInfo>
{
    protected override string? GetExtension(PropertyExtensionInfo info)
    {
        var extensionText =
            $"public static {info.ControlTypeName} {info.ExtensionName}(this {info.ControlTypeName} control, Func<{info.ValueType}> func, Action<{info.ValueType}>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null){Environment.NewLine}" +
            $"   => control._set((v) => control.{info.ExtensionName} = v, func, onChanged, expression);";

        return extensionText;
    }
}