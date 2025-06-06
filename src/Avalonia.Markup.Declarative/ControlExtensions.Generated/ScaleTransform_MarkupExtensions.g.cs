#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
[global::System.CodeDom.Compiler.GeneratedCode("AvaloniaExtensionGenerator", "1.0.0.0")]
[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class ScaleTransform_MarkupExtensions
{
//================= Properties ======================//
 // ScaleX

/*ValueSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleX(this Avalonia.Media.ScaleTransform control, System.Double value)  
=> control._set(() => control.ScaleX = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleX(this Avalonia.Media.ScaleTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleXProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.ScaleTransform ScaleX(this Avalonia.Media.ScaleTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.ScaleTransform.ScaleXProperty, ps, () => control.ScaleX = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleX(this Avalonia.Media.ScaleTransform control, IBinding binding)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleXProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleX(this Avalonia.Media.ScaleTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleXProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.ScaleTransform ScaleX<TValue>(this Avalonia.Media.ScaleTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.ScaleTransform.ScaleXProperty, ps, () => control.ScaleX = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // ScaleY

/*ValueSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleY(this Avalonia.Media.ScaleTransform control, System.Double value)  
=> control._set(() => control.ScaleY = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleY(this Avalonia.Media.ScaleTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleYProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.ScaleTransform ScaleY(this Avalonia.Media.ScaleTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.ScaleTransform.ScaleYProperty, ps, () => control.ScaleY = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleY(this Avalonia.Media.ScaleTransform control, IBinding binding)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleYProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.ScaleTransform ScaleY(this Avalonia.Media.ScaleTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.ScaleTransform.ScaleYProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.ScaleTransform ScaleY<TValue>(this Avalonia.Media.ScaleTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.ScaleTransform.ScaleYProperty, ps, () => control.ScaleY = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
