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
public static partial class Expander_MarkupExtensions
{
//================= Properties ======================//
 // ContentTransition

/*ValueSetterGenerator*/
public static T ContentTransition<T>(this T control, Avalonia.Animation.IPageTransition value) where T : Avalonia.Controls.Expander 
=> control._set(() => control.ContentTransition = value!);

/*BindFromExpressionSetterGenerator*/
public static T ContentTransition<T>(this T control, Func<Avalonia.Animation.IPageTransition> func, Action<Avalonia.Animation.IPageTransition>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ContentTransitionProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T ContentTransition<T>(this T control,Avalonia.Animation.IPageTransition value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.ContentTransitionProperty, ps, () => control.ContentTransition = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T ContentTransition<T>(this T control, IBinding binding) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ContentTransitionProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T ContentTransition<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ContentTransitionProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T ContentTransition<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.IPageTransition> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.ContentTransitionProperty, ps, () => control.ContentTransition = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // ExpandDirection

/*ValueSetterGenerator*/
public static T ExpandDirection<T>(this T control, Avalonia.Controls.ExpandDirection value) where T : Avalonia.Controls.Expander 
=> control._set(() => control.ExpandDirection = value!);

/*BindFromExpressionSetterGenerator*/
public static T ExpandDirection<T>(this T control, Func<Avalonia.Controls.ExpandDirection> func, Action<Avalonia.Controls.ExpandDirection>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ExpandDirectionProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T ExpandDirection<T>(this T control,Avalonia.Controls.ExpandDirection value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.ExpandDirectionProperty, ps, () => control.ExpandDirection = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T ExpandDirection<T>(this T control, IBinding binding) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ExpandDirectionProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T ExpandDirection<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.ExpandDirectionProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T ExpandDirection<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Controls.ExpandDirection> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.ExpandDirectionProperty, ps, () => control.ExpandDirection = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // IsExpanded

/*ValueSetterGenerator*/
public static T IsExpanded<T>(this T control, System.Boolean value) where T : Avalonia.Controls.Expander 
=> control._set(() => control.IsExpanded = value!);

/*BindFromExpressionSetterGenerator*/
public static T IsExpanded<T>(this T control, Func<System.Boolean> func, Action<System.Boolean>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.IsExpandedProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T IsExpanded<T>(this T control,System.Boolean value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.IsExpandedProperty, ps, () => control.IsExpanded = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T IsExpanded<T>(this T control, IBinding binding) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.IsExpandedProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T IsExpanded<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Expander 
   => control._set(Avalonia.Controls.Expander.IsExpandedProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T IsExpanded<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Boolean> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Expander 
=> control._setEx(Avalonia.Controls.Expander.IsExpandedProperty, ps, () => control.IsExpanded = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Events ======================//
 // Collapsed

/*ActionToEventGenerator*/
public static T OnCollapsed<T>(this T control, Action<Avalonia.Interactivity.RoutedEventArgs> action, Avalonia.Interactivity.RoutingStrategies? routes = null) where T : Avalonia.Controls.Expander 
{
  control.AddHandler(Avalonia.Controls.Expander.CollapsedEvent, (_, args) => action(args), routes ?? Avalonia.Controls.Expander.CollapsedEvent.RoutingStrategies);
  return control;
}



 // Collapsing

/*ActionToEventGenerator*/
public static T OnCollapsing<T>(this T control, Action<Avalonia.Interactivity.CancelRoutedEventArgs> action, Avalonia.Interactivity.RoutingStrategies? routes = null) where T : Avalonia.Controls.Expander 
{
  control.AddHandler(Avalonia.Controls.Expander.CollapsingEvent, (_, args) => action(args), routes ?? Avalonia.Controls.Expander.CollapsingEvent.RoutingStrategies);
  return control;
}



 // Expanded

/*ActionToEventGenerator*/
public static T OnExpanded<T>(this T control, Action<Avalonia.Interactivity.RoutedEventArgs> action, Avalonia.Interactivity.RoutingStrategies? routes = null) where T : Avalonia.Controls.Expander 
{
  control.AddHandler(Avalonia.Controls.Expander.ExpandedEvent, (_, args) => action(args), routes ?? Avalonia.Controls.Expander.ExpandedEvent.RoutingStrategies);
  return control;
}



 // Expanding

/*ActionToEventGenerator*/
public static T OnExpanding<T>(this T control, Action<Avalonia.Interactivity.CancelRoutedEventArgs> action, Avalonia.Interactivity.RoutingStrategies? routes = null) where T : Avalonia.Controls.Expander 
{
  control.AddHandler(Avalonia.Controls.Expander.ExpandingEvent, (_, args) => action(args), routes ?? Avalonia.Controls.Expander.ExpandingEvent.RoutingStrategies);
  return control;
}




//================= Styles ======================//
 // ContentTransition

/*ValueStyleSetterGenerator*/
public static Style<T> ContentTransition<T>(this Style<T> style, Avalonia.Animation.IPageTransition value) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.ContentTransitionProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> ContentTransition<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.ContentTransitionProperty, binding);


 // ExpandDirection

/*ValueStyleSetterGenerator*/
public static Style<T> ExpandDirection<T>(this Style<T> style, Avalonia.Controls.ExpandDirection value) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.ExpandDirectionProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> ExpandDirection<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.ExpandDirectionProperty, binding);


 // IsExpanded

/*ValueStyleSetterGenerator*/
public static Style<T> IsExpanded<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.IsExpandedProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> IsExpanded<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Expander 
=> style._addSetter(Avalonia.Controls.Expander.IsExpandedProperty, binding);



}
