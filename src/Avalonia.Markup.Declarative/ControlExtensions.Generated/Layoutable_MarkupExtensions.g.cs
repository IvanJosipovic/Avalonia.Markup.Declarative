#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class Layoutable_MarkupExtensions
{
//================= Properties ======================//
 // WidthProperty

/*BindFromExpressionSetterGenerator*/
public static T Width<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.WidthProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T Width<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.WidthProperty, ps, () => control.Width = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Width<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.WidthProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Width<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.WidthProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T Width<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.WidthProperty, ps, () => control.Width = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // HeightProperty

/*BindFromExpressionSetterGenerator*/
public static T Height<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HeightProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T Height<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.HeightProperty, ps, () => control.Height = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Height<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HeightProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Height<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HeightProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T Height<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.HeightProperty, ps, () => control.Height = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MinWidthProperty

/*BindFromExpressionSetterGenerator*/
public static T MinWidth<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinWidthProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T MinWidth<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MinWidthProperty, ps, () => control.MinWidth = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T MinWidth<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinWidthProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T MinWidth<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinWidthProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T MinWidth<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MinWidthProperty, ps, () => control.MinWidth = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MaxWidthProperty

/*BindFromExpressionSetterGenerator*/
public static T MaxWidth<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxWidthProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T MaxWidth<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MaxWidthProperty, ps, () => control.MaxWidth = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T MaxWidth<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxWidthProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T MaxWidth<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxWidthProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T MaxWidth<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MaxWidthProperty, ps, () => control.MaxWidth = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MinHeightProperty

/*BindFromExpressionSetterGenerator*/
public static T MinHeight<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinHeightProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T MinHeight<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MinHeightProperty, ps, () => control.MinHeight = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T MinHeight<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinHeightProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T MinHeight<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MinHeightProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T MinHeight<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MinHeightProperty, ps, () => control.MinHeight = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MaxHeightProperty

/*BindFromExpressionSetterGenerator*/
public static T MaxHeight<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxHeightProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T MaxHeight<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MaxHeightProperty, ps, () => control.MaxHeight = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T MaxHeight<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxHeightProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T MaxHeight<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MaxHeightProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T MaxHeight<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MaxHeightProperty, ps, () => control.MaxHeight = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MarginProperty

/*BindFromExpressionSetterGenerator*/
public static T Margin<T>(this T control, Func<Avalonia.Thickness> func, Action<Avalonia.Thickness>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MarginProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T Margin<T>(this T control, Avalonia.Thickness value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MarginProperty, ps, () => control.Margin = value, bindingMode, converter, bindingSource);

/*ValueOverloadsSetterGenerator*/

public static T Margin<T>(this T control, System.Double uniformLength = default) where T : Avalonia.Layout.Layoutable
   => control._set(() => control.Margin = new Avalonia.Thickness(uniformLength));
public static T Margin<T>(this T control, System.Double horizontal = default, System.Double vertical = default) where T : Avalonia.Layout.Layoutable
   => control._set(() => control.Margin = new Avalonia.Thickness(horizontal, vertical));
public static T Margin<T>(this T control, System.Double left = default, System.Double top = default, System.Double right = default, System.Double bottom = default) where T : Avalonia.Layout.Layoutable
   => control._set(() => control.Margin = new Avalonia.Thickness(left, top, right, bottom));

/*BindSetterGenerator*/
public static T Margin<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MarginProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Margin<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.MarginProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T Margin<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Thickness> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.MarginProperty, ps, () => control.Margin = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // HorizontalAlignmentProperty

/*BindFromExpressionSetterGenerator*/
public static T HorizontalAlignment<T>(this T control, Func<Avalonia.Layout.HorizontalAlignment> func, Action<Avalonia.Layout.HorizontalAlignment>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T HorizontalAlignment<T>(this T control, Avalonia.Layout.HorizontalAlignment value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, ps, () => control.HorizontalAlignment = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T HorizontalAlignment<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T HorizontalAlignment<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T HorizontalAlignment<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Layout.HorizontalAlignment> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, ps, () => control.HorizontalAlignment = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // VerticalAlignmentProperty

/*BindFromExpressionSetterGenerator*/
public static T VerticalAlignment<T>(this T control, Func<Avalonia.Layout.VerticalAlignment> func, Action<Avalonia.Layout.VerticalAlignment>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T VerticalAlignment<T>(this T control, Avalonia.Layout.VerticalAlignment value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, ps, () => control.VerticalAlignment = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T VerticalAlignment<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T VerticalAlignment<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T VerticalAlignment<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Layout.VerticalAlignment> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, ps, () => control.VerticalAlignment = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // UseLayoutRoundingProperty

/*BindFromExpressionSetterGenerator*/
public static T UseLayoutRounding<T>(this T control, Func<System.Boolean> func, Action<System.Boolean>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T UseLayoutRounding<T>(this T control, System.Boolean value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, ps, () => control.UseLayoutRounding = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T UseLayoutRounding<T>(this T control, IBinding binding) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T UseLayoutRounding<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Layout.Layoutable
   => control._set(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T UseLayoutRounding<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Boolean> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Layout.Layoutable
=> control._setEx(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, ps, () => control.UseLayoutRounding = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//
 // EffectiveViewportChanged

/*ActionToEventGenerator*/
    public static T OnEffectiveViewportChanged<T>(this T control, Action<Avalonia.Layout.EffectiveViewportChangedEventArgs> action) where T : Avalonia.Layout.Layoutable => 
        control._setEvent((System.EventHandler<Avalonia.Layout.EffectiveViewportChangedEventArgs>) ((arg0, arg1) => action(arg1)), h => control.EffectiveViewportChanged += h);


 // LayoutUpdated

/*ActionToEventGenerator*/
    public static T OnLayoutUpdated<T>(this T control, Action<System.EventArgs> action) where T : Avalonia.Layout.Layoutable => 
        control._setEvent((System.EventHandler) ((arg0, arg1) => action(arg1)), h => control.LayoutUpdated += h);



//================= Styles ======================//
 // WidthProperty

/*ValueStyleSetterGenerator*/
public static Style<T> Width<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.WidthProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> Width<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.WidthProperty, binding);


 // HeightProperty

/*ValueStyleSetterGenerator*/
public static Style<T> Height<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.HeightProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> Height<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.HeightProperty, binding);


 // MinWidthProperty

/*ValueStyleSetterGenerator*/
public static Style<T> MinWidth<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MinWidthProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> MinWidth<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MinWidthProperty, binding);


 // MaxWidthProperty

/*ValueStyleSetterGenerator*/
public static Style<T> MaxWidth<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MaxWidthProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> MaxWidth<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MaxWidthProperty, binding);


 // MinHeightProperty

/*ValueStyleSetterGenerator*/
public static Style<T> MinHeight<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MinHeightProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> MinHeight<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MinHeightProperty, binding);


 // MaxHeightProperty

/*ValueStyleSetterGenerator*/
public static Style<T> MaxHeight<T>(this Style<T> style, System.Double value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MaxHeightProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> MaxHeight<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MaxHeightProperty, binding);


 // MarginProperty

/*ValueStyleSetterGenerator*/
public static Style<T> Margin<T>(this Style<T> style, Avalonia.Thickness value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MarginProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> Margin<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.MarginProperty, binding);

/*ValueOverloadsStyleSetterGenerator*/
public static Style<T> Margin<T>(this Style<T> style, System.Double uniformLength) where T : Avalonia.Layout.Layoutable
   => style._addSetter(Avalonia.Layout.Layoutable.MarginProperty, new Avalonia.Thickness(uniformLength));public static Style<T> Margin<T>(this Style<T> style, System.Double horizontal, System.Double vertical) where T : Avalonia.Layout.Layoutable
   => style._addSetter(Avalonia.Layout.Layoutable.MarginProperty, new Avalonia.Thickness(horizontal, vertical));public static Style<T> Margin<T>(this Style<T> style, System.Double left, System.Double top, System.Double right, System.Double bottom) where T : Avalonia.Layout.Layoutable
   => style._addSetter(Avalonia.Layout.Layoutable.MarginProperty, new Avalonia.Thickness(left, top, right, bottom));


 // HorizontalAlignmentProperty

/*ValueStyleSetterGenerator*/
public static Style<T> HorizontalAlignment<T>(this Style<T> style, Avalonia.Layout.HorizontalAlignment value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> HorizontalAlignment<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.HorizontalAlignmentProperty, binding);


 // VerticalAlignmentProperty

/*ValueStyleSetterGenerator*/
public static Style<T> VerticalAlignment<T>(this Style<T> style, Avalonia.Layout.VerticalAlignment value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> VerticalAlignment<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.VerticalAlignmentProperty, binding);


 // UseLayoutRoundingProperty

/*ValueStyleSetterGenerator*/
public static Style<T> UseLayoutRounding<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> UseLayoutRounding<T>(this Style<T> style, IBinding binding) where T : Avalonia.Layout.Layoutable
=> style._addSetter(Avalonia.Layout.Layoutable.UseLayoutRoundingProperty, binding);



}
