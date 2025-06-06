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
public static partial class TransitionBase_MarkupExtensions
{
//================= Properties ======================//
 // Duration

/*ValueSetterGenerator*/
public static T Duration<T>(this T control, System.TimeSpan value) where T : Avalonia.Animation.TransitionBase 
=> control._set(() => control.Duration = value!);

/*BindFromExpressionSetterGenerator*/
public static T Duration<T>(this T control, Func<System.TimeSpan> func, Action<System.TimeSpan>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DurationProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Duration<T>(this T control,System.TimeSpan value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.DurationProperty, ps, () => control.Duration = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Duration<T>(this T control, IBinding binding) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DurationProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Duration<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DurationProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Duration<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.TimeSpan> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.DurationProperty, ps, () => control.Duration = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Delay

/*ValueSetterGenerator*/
public static T Delay<T>(this T control, System.TimeSpan value) where T : Avalonia.Animation.TransitionBase 
=> control._set(() => control.Delay = value!);

/*BindFromExpressionSetterGenerator*/
public static T Delay<T>(this T control, Func<System.TimeSpan> func, Action<System.TimeSpan>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DelayProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Delay<T>(this T control,System.TimeSpan value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.DelayProperty, ps, () => control.Delay = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Delay<T>(this T control, IBinding binding) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DelayProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Delay<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.DelayProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Delay<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.TimeSpan> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.DelayProperty, ps, () => control.Delay = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Easing

/*ValueSetterGenerator*/
public static T Easing<T>(this T control, Avalonia.Animation.Easings.Easing value) where T : Avalonia.Animation.TransitionBase 
=> control._set(() => control.Easing = value!);

/*BindFromExpressionSetterGenerator*/
public static T Easing<T>(this T control, Func<Avalonia.Animation.Easings.Easing> func, Action<Avalonia.Animation.Easings.Easing>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.EasingProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Easing<T>(this T control,Avalonia.Animation.Easings.Easing value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.EasingProperty, ps, () => control.Easing = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Easing<T>(this T control, IBinding binding) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.EasingProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Easing<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Animation.TransitionBase 
   => control._set(Avalonia.Animation.TransitionBase.EasingProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Easing<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.Easings.Easing> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Animation.TransitionBase 
=> control._setEx(Avalonia.Animation.TransitionBase.EasingProperty, ps, () => control.Easing = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
