#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class ManagedFileChooserOverwritePrompt_MarkupExtensions
{
//================= Properties ======================//
 // FileNameProperty

/*BindFromExpressionSetterGenerator*/
public static T FileName<T>(this T control, Func<System.String> func, Action<System.String>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Dialogs.ManagedFileChooserOverwritePrompt
   => control._set(Avalonia.Dialogs.ManagedFileChooserOverwritePrompt.FileNameProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T FileName<T>(this T control, System.String value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Dialogs.ManagedFileChooserOverwritePrompt
=> control._setEx(Avalonia.Dialogs.ManagedFileChooserOverwritePrompt.FileNameProperty, ps, () => control.FileName = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T FileName<T>(this T control, IBinding binding) where T : Avalonia.Dialogs.ManagedFileChooserOverwritePrompt
   => control._set(Avalonia.Dialogs.ManagedFileChooserOverwritePrompt.FileNameProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T FileName<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Dialogs.ManagedFileChooserOverwritePrompt
   => control._set(Avalonia.Dialogs.ManagedFileChooserOverwritePrompt.FileNameProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T FileName<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.String> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Dialogs.ManagedFileChooserOverwritePrompt
=> control._setEx(Avalonia.Dialogs.ManagedFileChooserOverwritePrompt.FileNameProperty, ps, () => control.FileName = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//

//================= Styles ======================//

}
