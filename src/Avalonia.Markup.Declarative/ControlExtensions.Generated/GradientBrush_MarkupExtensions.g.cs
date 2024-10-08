#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class GradientBrush_MarkupExtensions
{
//================= Properties ======================//
 // SpreadMethodProperty

/*BindFromExpressionSetterGenerator*/
public static T SpreadMethod<T>(this T control, Func<Avalonia.Media.GradientSpreadMethod> func, Action<Avalonia.Media.GradientSpreadMethod>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.SpreadMethodProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T SpreadMethod<T>(this T control, Avalonia.Media.GradientSpreadMethod value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.GradientBrush
=> control._setEx(Avalonia.Media.GradientBrush.SpreadMethodProperty, ps, () => control.SpreadMethod = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T SpreadMethod<T>(this T control, IBinding binding) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.SpreadMethodProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T SpreadMethod<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.SpreadMethodProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T SpreadMethod<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.GradientSpreadMethod> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.GradientBrush
=> control._setEx(Avalonia.Media.GradientBrush.SpreadMethodProperty, ps, () => control.SpreadMethod = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // GradientStopsProperty

/*BindFromExpressionSetterGenerator*/
public static T GradientStops<T>(this T control, Func<Avalonia.Media.GradientStops> func, Action<Avalonia.Media.GradientStops>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.GradientStopsProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T GradientStops<T>(this T control, Avalonia.Media.GradientStops value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.GradientBrush
=> control._setEx(Avalonia.Media.GradientBrush.GradientStopsProperty, ps, () => control.GradientStops = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T GradientStops<T>(this T control, IBinding binding) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.GradientStopsProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T GradientStops<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.GradientBrush
   => control._set(Avalonia.Media.GradientBrush.GradientStopsProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T GradientStops<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.GradientStops> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.GradientBrush
=> control._setEx(Avalonia.Media.GradientBrush.GradientStopsProperty, ps, () => control.GradientStops = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//

//================= Styles ======================//

}
