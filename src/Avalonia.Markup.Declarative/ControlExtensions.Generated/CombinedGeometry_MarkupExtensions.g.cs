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
public static partial class CombinedGeometry_MarkupExtensions
{
//================= Properties ======================//
 // Geometry1

/*ValueSetterGenerator*/
public static T Geometry1<T>(this T control, Avalonia.Media.Geometry value) where T : Avalonia.Media.CombinedGeometry 
=> control._set(() => control.Geometry1 = value!);

/*BindFromExpressionSetterGenerator*/
public static T Geometry1<T>(this T control, Func<Avalonia.Media.Geometry> func, Action<Avalonia.Media.Geometry>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry1Property!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Geometry1<T>(this T control,Avalonia.Media.Geometry value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.Geometry1Property, ps, () => control.Geometry1 = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Geometry1<T>(this T control, IBinding binding) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry1Property, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Geometry1<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry1Property, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Geometry1<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Geometry> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.Geometry1Property, ps, () => control.Geometry1 = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Geometry2

/*ValueSetterGenerator*/
public static T Geometry2<T>(this T control, Avalonia.Media.Geometry value) where T : Avalonia.Media.CombinedGeometry 
=> control._set(() => control.Geometry2 = value!);

/*BindFromExpressionSetterGenerator*/
public static T Geometry2<T>(this T control, Func<Avalonia.Media.Geometry> func, Action<Avalonia.Media.Geometry>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry2Property!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Geometry2<T>(this T control,Avalonia.Media.Geometry value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.Geometry2Property, ps, () => control.Geometry2 = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Geometry2<T>(this T control, IBinding binding) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry2Property, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Geometry2<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.Geometry2Property, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Geometry2<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Geometry> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.Geometry2Property, ps, () => control.Geometry2 = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // GeometryCombineMode

/*ValueSetterGenerator*/
public static T GeometryCombineMode<T>(this T control, Avalonia.Media.GeometryCombineMode value) where T : Avalonia.Media.CombinedGeometry 
=> control._set(() => control.GeometryCombineMode = value!);

/*BindFromExpressionSetterGenerator*/
public static T GeometryCombineMode<T>(this T control, Func<Avalonia.Media.GeometryCombineMode> func, Action<Avalonia.Media.GeometryCombineMode>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.GeometryCombineModeProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T GeometryCombineMode<T>(this T control,Avalonia.Media.GeometryCombineMode value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.GeometryCombineModeProperty, ps, () => control.GeometryCombineMode = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T GeometryCombineMode<T>(this T control, IBinding binding) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.GeometryCombineModeProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T GeometryCombineMode<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.CombinedGeometry 
   => control._set(Avalonia.Media.CombinedGeometry.GeometryCombineModeProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T GeometryCombineMode<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.GeometryCombineMode> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Media.CombinedGeometry 
=> control._setEx(Avalonia.Media.CombinedGeometry.GeometryCombineModeProperty, ps, () => control.GeometryCombineMode = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
