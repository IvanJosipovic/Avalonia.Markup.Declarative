#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
public static partial class ExperimentalAcrylicMaterial_MarkupExtensions
{
//================= Properties ======================//
 // TintColorProperty

/*BindFromExpressionSetterGenerator*/
public static T TintColor<T>(this T control, Func<Avalonia.Media.Color> func, Action<Avalonia.Media.Color>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintColorProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T TintColor<T>(this T control, Avalonia.Media.Color value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.TintColorProperty, ps, () => control.TintColor = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T TintColor<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintColorProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T TintColor<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintColorProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T TintColor<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Color> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.TintColorProperty, ps, () => control.TintColor = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // BackgroundSourceProperty

/*BindFromExpressionSetterGenerator*/
public static T BackgroundSource<T>(this T control, Func<Avalonia.Media.AcrylicBackgroundSource> func, Action<Avalonia.Media.AcrylicBackgroundSource>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.BackgroundSourceProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T BackgroundSource<T>(this T control, Avalonia.Media.AcrylicBackgroundSource value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.BackgroundSourceProperty, ps, () => control.BackgroundSource = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T BackgroundSource<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.BackgroundSourceProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T BackgroundSource<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.BackgroundSourceProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T BackgroundSource<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.AcrylicBackgroundSource> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.BackgroundSourceProperty, ps, () => control.BackgroundSource = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // TintOpacityProperty

/*BindFromExpressionSetterGenerator*/
public static T TintOpacity<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintOpacityProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T TintOpacity<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.TintOpacityProperty, ps, () => control.TintOpacity = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T TintOpacity<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintOpacityProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T TintOpacity<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.TintOpacityProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T TintOpacity<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.TintOpacityProperty, ps, () => control.TintOpacity = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // MaterialOpacityProperty

/*BindFromExpressionSetterGenerator*/
public static T MaterialOpacity<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.MaterialOpacityProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T MaterialOpacity<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.MaterialOpacityProperty, ps, () => control.MaterialOpacity = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T MaterialOpacity<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.MaterialOpacityProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T MaterialOpacity<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.MaterialOpacityProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T MaterialOpacity<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.MaterialOpacityProperty, ps, () => control.MaterialOpacity = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // PlatformTransparencyCompensationLevelProperty

/*BindFromExpressionSetterGenerator*/
public static T PlatformTransparencyCompensationLevel<T>(this T control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T PlatformTransparencyCompensationLevel<T>(this T control, System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty, ps, () => control.PlatformTransparencyCompensationLevel = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T PlatformTransparencyCompensationLevel<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T PlatformTransparencyCompensationLevel<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T PlatformTransparencyCompensationLevel<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty, ps, () => control.PlatformTransparencyCompensationLevel = converter.TryConvert(value), bindingMode, converter, bindingSource);


 // FallbackColorProperty

/*BindFromExpressionSetterGenerator*/
public static T FallbackColor<T>(this T control, Func<Avalonia.Media.Color> func, Action<Avalonia.Media.Color>? onChanged = null, [CallerArgumentExpression("func")] string? expression = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.FallbackColorProperty, func, onChanged, expression);

/*MagicalSetterGenerator*/
public static T FallbackColor<T>(this T control, Avalonia.Media.Color value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.FallbackColorProperty, ps, () => control.FallbackColor = value, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T FallbackColor<T>(this T control, IBinding binding) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.FallbackColorProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T FallbackColor<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
   => control._set(Avalonia.Media.ExperimentalAcrylicMaterial.FallbackColorProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
public static T FallbackColor<T,TValue>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Color> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression("value")] string? ps = null) where T : Avalonia.Media.ExperimentalAcrylicMaterial
=> control._setEx(Avalonia.Media.ExperimentalAcrylicMaterial.FallbackColorProperty, ps, () => control.FallbackColor = converter.TryConvert(value), bindingMode, converter, bindingSource);



//================= Events ======================//
 // Invalidated

/*ActionToEventGenerator*/
    public static T OnInvalidated<T>(this T control, Action<System.EventArgs> action) where T : Avalonia.Media.ExperimentalAcrylicMaterial => 
        control._setEvent((System.EventHandler) ((arg0, arg1) => action(arg1)), h => control.Invalidated += h);



//================= Styles ======================//

}
