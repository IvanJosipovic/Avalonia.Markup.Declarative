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
public static partial class Animation_MarkupExtensions
{
//================= Properties ======================//
 // Duration

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation Duration(this Avalonia.Animation.Animation control, System.TimeSpan value)  
=> control._set(() => control.Duration = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation Duration(this Avalonia.Animation.Animation control, Func<System.TimeSpan> func, Action<System.TimeSpan>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.DurationProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Duration(this Avalonia.Animation.Animation control,System.TimeSpan value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DurationProperty, ps, () => control.Duration = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation Duration(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.DurationProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation Duration(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.DurationProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Duration<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, System.TimeSpan> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DurationProperty, ps, () => control.Duration = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // IterationCount

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, Avalonia.Animation.IterationCount value)  
=> control._set(() => control.IterationCount = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, Func<Avalonia.Animation.IterationCount> func, Action<Avalonia.Animation.IterationCount>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.IterationCountProperty!, func, onChanged, expression);

/*ValueOverloadsSetterGenerator*/

public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, System.UInt64 value = default!)  
   => control._set(() => control.IterationCount = new Avalonia.Animation.IterationCount(value));
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, System.UInt64 value = default!, Avalonia.Animation.IterationType type = default!)  
   => control._set(() => control.IterationCount = new Avalonia.Animation.IterationCount(value, type));

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control,Avalonia.Animation.IterationCount value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.IterationCountProperty, ps, () => control.IterationCount = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.IterationCountProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation IterationCount(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.IterationCountProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation IterationCount<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.IterationCount> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.IterationCountProperty, ps, () => control.IterationCount = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // PlaybackDirection

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation PlaybackDirection(this Avalonia.Animation.Animation control, Avalonia.Animation.PlaybackDirection value)  
=> control._set(() => control.PlaybackDirection = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation PlaybackDirection(this Avalonia.Animation.Animation control, Func<Avalonia.Animation.PlaybackDirection> func, Action<Avalonia.Animation.PlaybackDirection>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.PlaybackDirectionProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation PlaybackDirection(this Avalonia.Animation.Animation control,Avalonia.Animation.PlaybackDirection value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.PlaybackDirectionProperty, ps, () => control.PlaybackDirection = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation PlaybackDirection(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.PlaybackDirectionProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation PlaybackDirection(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.PlaybackDirectionProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation PlaybackDirection<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.PlaybackDirection> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.PlaybackDirectionProperty, ps, () => control.PlaybackDirection = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // FillMode

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation FillMode(this Avalonia.Animation.Animation control, Avalonia.Animation.FillMode value)  
=> control._set(() => control.FillMode = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation FillMode(this Avalonia.Animation.Animation control, Func<Avalonia.Animation.FillMode> func, Action<Avalonia.Animation.FillMode>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.FillModeProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation FillMode(this Avalonia.Animation.Animation control,Avalonia.Animation.FillMode value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.FillModeProperty, ps, () => control.FillMode = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation FillMode(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.FillModeProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation FillMode(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.FillModeProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation FillMode<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.FillMode> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.FillModeProperty, ps, () => control.FillMode = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Easing

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation Easing(this Avalonia.Animation.Animation control, Avalonia.Animation.Easings.Easing value)  
=> control._set(() => control.Easing = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation Easing(this Avalonia.Animation.Animation control, Func<Avalonia.Animation.Easings.Easing> func, Action<Avalonia.Animation.Easings.Easing>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.EasingProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Easing(this Avalonia.Animation.Animation control,Avalonia.Animation.Easings.Easing value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.EasingProperty, ps, () => control.Easing = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation Easing(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.EasingProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation Easing(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.EasingProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Easing<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, Avalonia.Animation.Easings.Easing> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.EasingProperty, ps, () => control.Easing = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Delay

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation Delay(this Avalonia.Animation.Animation control, System.TimeSpan value)  
=> control._set(() => control.Delay = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation Delay(this Avalonia.Animation.Animation control, Func<System.TimeSpan> func, Action<System.TimeSpan>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.DelayProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Delay(this Avalonia.Animation.Animation control,System.TimeSpan value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DelayProperty, ps, () => control.Delay = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation Delay(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.DelayProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation Delay(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.DelayProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation Delay<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, System.TimeSpan> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DelayProperty, ps, () => control.Delay = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // DelayBetweenIterations

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation DelayBetweenIterations(this Avalonia.Animation.Animation control, System.TimeSpan value)  
=> control._set(() => control.DelayBetweenIterations = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation DelayBetweenIterations(this Avalonia.Animation.Animation control, Func<System.TimeSpan> func, Action<System.TimeSpan>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.DelayBetweenIterationsProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation DelayBetweenIterations(this Avalonia.Animation.Animation control,System.TimeSpan value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DelayBetweenIterationsProperty, ps, () => control.DelayBetweenIterations = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation DelayBetweenIterations(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.DelayBetweenIterationsProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation DelayBetweenIterations(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.DelayBetweenIterationsProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation DelayBetweenIterations<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, System.TimeSpan> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.DelayBetweenIterationsProperty, ps, () => control.DelayBetweenIterations = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // SpeedRatio

/*ValueSetterGenerator*/
public static Avalonia.Animation.Animation SpeedRatio(this Avalonia.Animation.Animation control, System.Double value)  
=> control._set(() => control.SpeedRatio = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Animation.Animation SpeedRatio(this Avalonia.Animation.Animation control, Func<System.Double> func, Action<System.Double>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Animation.Animation.SpeedRatioProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation SpeedRatio(this Avalonia.Animation.Animation control,System.Double value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.SpeedRatioProperty, ps, () => control.SpeedRatio = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Animation.Animation SpeedRatio(this Avalonia.Animation.Animation control, IBinding binding)  
   => control._set(Avalonia.Animation.Animation.SpeedRatioProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Animation.Animation SpeedRatio(this Avalonia.Animation.Animation control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Animation.Animation.SpeedRatioProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Animation.Animation SpeedRatio<TValue>(this Avalonia.Animation.Animation control, TValue value, FuncValueConverter<TValue, System.Double> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Animation.Animation.SpeedRatioProperty, ps, () => control.SpeedRatio = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
