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
public static partial class Arc_MarkupExtensions
{
//================= Properties ======================//
 // StartAngle

/*ValueSetterGenerator*/
public static T StartAngle<T>(this T control, System.Double value) where T : Avalonia.Controls.Shapes.Arc 
=> control._set(() => control.StartAngle = value!);

/*BindFromExpressionSetterGenerator*/
public static T StartAngle<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.StartAngleProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T StartAngle<T>(this T control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Shapes.Arc 
=> control._setEx(Avalonia.Controls.Shapes.Arc.StartAngleProperty, ps, () => control.StartAngle = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T StartAngle<T>(this T control, IBinding binding) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.StartAngleProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T StartAngle<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.StartAngleProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T StartAngle<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Shapes.Arc 
=> control._setEx(Avalonia.Controls.Shapes.Arc.StartAngleProperty, ps, () => control.StartAngle = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // SweepAngle

/*ValueSetterGenerator*/
public static T SweepAngle<T>(this T control, System.Double value) where T : Avalonia.Controls.Shapes.Arc 
=> control._set(() => control.SweepAngle = value!);

/*BindFromExpressionSetterGenerator*/
public static T SweepAngle<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.SweepAngleProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T SweepAngle<T>(this T control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Shapes.Arc 
=> control._setEx(Avalonia.Controls.Shapes.Arc.SweepAngleProperty, ps, () => control.SweepAngle = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T SweepAngle<T>(this T control, IBinding binding) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.SweepAngleProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T SweepAngle<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Shapes.Arc 
   => control._set(Avalonia.Controls.Shapes.Arc.SweepAngleProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T SweepAngle<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Shapes.Arc 
=> control._setEx(Avalonia.Controls.Shapes.Arc.SweepAngleProperty, ps, () => control.SweepAngle = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Styles ======================//
 // StartAngle

/*ValueStyleSetterGenerator*/
public static Style<T> StartAngle<T>(this Style<T> style, System.Double value) where T : Avalonia.Controls.Shapes.Arc 
=> style._addSetter(Avalonia.Controls.Shapes.Arc.StartAngleProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> StartAngle<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Shapes.Arc 
=> style._addSetter(Avalonia.Controls.Shapes.Arc.StartAngleProperty, binding);


 // SweepAngle

/*ValueStyleSetterGenerator*/
public static Style<T> SweepAngle<T>(this Style<T> style, System.Double value) where T : Avalonia.Controls.Shapes.Arc 
=> style._addSetter(Avalonia.Controls.Shapes.Arc.SweepAngleProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> SweepAngle<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Shapes.Arc 
=> style._addSetter(Avalonia.Controls.Shapes.Arc.SweepAngleProperty, binding);



}
