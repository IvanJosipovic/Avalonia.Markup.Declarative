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
public static partial class Rotate3DTransform_MarkupExtensions
{
//================= Properties ======================//
 // AngleX

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleX(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.AngleX = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleX(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleXProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleX(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleXProperty, ps, () => control.AngleX = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleX(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleXProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleX(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleXProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleX<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleXProperty, ps, () => control.AngleX = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // AngleY

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleY(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.AngleY = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleY(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleYProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleY(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleYProperty, ps, () => control.AngleY = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleY(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleYProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleY(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleYProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleY<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleYProperty, ps, () => control.AngleY = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // AngleZ

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleZ(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.AngleZ = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleZ(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleZProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleZ(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleZProperty, ps, () => control.AngleZ = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleZ(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleZProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform AngleZ(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.AngleZProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform AngleZ<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.AngleZProperty, ps, () => control.AngleZ = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // CenterX

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterX(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.CenterX = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterX(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterXProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterX(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterXProperty, ps, () => control.CenterX = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterX(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterXProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterX(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterXProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterX<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterXProperty, ps, () => control.CenterX = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // CenterY

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterY(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.CenterY = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterY(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterYProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterY(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterYProperty, ps, () => control.CenterY = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterY(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterYProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterY(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterYProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterY<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterYProperty, ps, () => control.CenterY = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // CenterZ

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterZ(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.CenterZ = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterZ(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterZProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterZ(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterZProperty, ps, () => control.CenterZ = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterZ(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterZProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform CenterZ(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.CenterZProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform CenterZ<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.CenterZProperty, ps, () => control.CenterZ = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Depth

/*ValueSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform Depth(this Avalonia.Media.Rotate3DTransform control, System.Double value)  
=> control._set(() => control.Depth = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform Depth(this Avalonia.Media.Rotate3DTransform control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.DepthProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform Depth(this Avalonia.Media.Rotate3DTransform control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.DepthProperty, ps, () => control.Depth = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform Depth(this Avalonia.Media.Rotate3DTransform control, IBinding binding)  
   => control._set(Avalonia.Media.Rotate3DTransform.DepthProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.Rotate3DTransform Depth(this Avalonia.Media.Rotate3DTransform control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.Rotate3DTransform.DepthProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.Rotate3DTransform Depth<TValue>(this Avalonia.Media.Rotate3DTransform control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.Rotate3DTransform.DepthProperty, ps, () => control.Depth = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
