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
public static partial class RefreshVisualizer_MarkupExtensions
{
//================= Properties ======================//
 // Orientation

/*ValueSetterGenerator*/
public static T Orientation<T>(this T control, Avalonia.Controls.RefreshVisualizerOrientation value) where T : Avalonia.Controls.RefreshVisualizer 
=> control._set(() => control.Orientation = value!);

/*BindFromExpressionSetterGenerator*/
public static T Orientation<T>(this T control, Func<Avalonia.Controls.RefreshVisualizerOrientation> func, Action<Avalonia.Controls.RefreshVisualizerOrientation>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.RefreshVisualizer 
   => control._set(Avalonia.Controls.RefreshVisualizer.OrientationProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Orientation<T>(this T control,Avalonia.Controls.RefreshVisualizerOrientation value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.RefreshVisualizer 
=> control._setEx(Avalonia.Controls.RefreshVisualizer.OrientationProperty, ps, () => control.Orientation = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Orientation<T>(this T control, IBinding binding) where T : Avalonia.Controls.RefreshVisualizer 
   => control._set(Avalonia.Controls.RefreshVisualizer.OrientationProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Orientation<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.RefreshVisualizer 
   => control._set(Avalonia.Controls.RefreshVisualizer.OrientationProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Orientation<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Controls.RefreshVisualizerOrientation> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.RefreshVisualizer 
=> control._setEx(Avalonia.Controls.RefreshVisualizer.OrientationProperty, ps, () => control.Orientation = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Events ======================//
 // RefreshRequested

/*ActionToEventGenerator*/
public static T OnRefreshRequested<T>(this T control, Action<Avalonia.Controls.RefreshRequestedEventArgs> action, Avalonia.Interactivity.RoutingStrategies? routes = null) where T : Avalonia.Controls.RefreshVisualizer 
{
  control.AddHandler(Avalonia.Controls.RefreshVisualizer.RefreshRequestedEvent, (_, args) => action(args), routes ?? Avalonia.Controls.RefreshVisualizer.RefreshRequestedEvent.RoutingStrategies);
  return control;
}




}
