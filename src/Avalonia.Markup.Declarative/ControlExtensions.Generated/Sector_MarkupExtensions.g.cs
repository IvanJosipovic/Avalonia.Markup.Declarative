#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class Sector_MarkupExtensions
{
//================= Properties ======================//
 // StartAngleProperty

/*BindFromExpressionSetterGenerator*/
public static T StartAngle<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.StartAngleProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T StartAngle<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Sector
=> control._setEx(Avalonia.Controls.Shapes.Sector.StartAngleProperty, ps, () => control.StartAngle = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T StartAngle<T>(this T control, IBinding binding) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.StartAngleProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T StartAngle<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.StartAngleProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T StartAngle<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Sector
=> control._setEx(Avalonia.Controls.Shapes.Sector.StartAngleProperty, ps, () => control.StartAngle = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // SweepAngleProperty

/*BindFromExpressionSetterGenerator*/
public static T SweepAngle<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T SweepAngle<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Sector
=> control._setEx(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, ps, () => control.SweepAngle = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T SweepAngle<T>(this T control, IBinding binding) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T SweepAngle<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Shapes.Sector
   => control._set(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T SweepAngle<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Sector
=> control._setEx(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, ps, () => control.SweepAngle = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//

//================= Styles ======================//
 // StartAngleProperty

/*ValueStyleSetterGenerator*/
public static Style<T> StartAngle<T>(this Style<T> style, System.Double value) where T : Avalonia.Controls.Shapes.Sector
=> style._addSetter(Avalonia.Controls.Shapes.Sector.StartAngleProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> StartAngle<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Shapes.Sector
=> style._addSetter(Avalonia.Controls.Shapes.Sector.StartAngleProperty, binding);


 // SweepAngleProperty

/*ValueStyleSetterGenerator*/
public static Style<T> SweepAngle<T>(this Style<T> style, System.Double value) where T : Avalonia.Controls.Shapes.Sector
=> style._addSetter(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> SweepAngle<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Shapes.Sector
=> style._addSetter(Avalonia.Controls.Shapes.Sector.SweepAngleProperty, binding);



}
