#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class Polygon_MarkupExtensions
{
//================= Properties ======================//
 // PointsProperty

/*BindFromExpressionSetterGenerator*/
public static T Points<T>(this T control, Func<System.Collections.Generic.IList<Avalonia.Point>> func, Action<System.Collections.Generic.IList<Avalonia.Point>>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Controls.Shapes.Polygon
   => control._set(Avalonia.Controls.Shapes.Polygon.PointsProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T Points<T>(this T control, System.Collections.Generic.IList<Avalonia.Point> value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Polygon
=> control._setEx(Avalonia.Controls.Shapes.Polygon.PointsProperty, ps, () => control.Points = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Points<T>(this T control, IBinding binding) where T : Avalonia.Controls.Shapes.Polygon
   => control._set(Avalonia.Controls.Shapes.Polygon.PointsProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Points<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Shapes.Polygon
   => control._set(Avalonia.Controls.Shapes.Polygon.PointsProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T Points<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Collections.Generic.IList<Avalonia.Point>> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Controls.Shapes.Polygon
=> control._setEx(Avalonia.Controls.Shapes.Polygon.PointsProperty, ps, () => control.Points = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//

//================= Styles ======================//
 // PointsProperty

/*ValueStyleSetterGenerator*/
public static Style<T> Points<T>(this Style<T> style, System.Collections.Generic.IList<Avalonia.Point> value) where T : Avalonia.Controls.Shapes.Polygon
=> style._addSetter(Avalonia.Controls.Shapes.Polygon.PointsProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> Points<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Shapes.Polygon
=> style._addSetter(Avalonia.Controls.Shapes.Polygon.PointsProperty, binding);



}