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
public static partial class KeyBinding_MarkupExtensions
{
//================= Properties ======================//
 // Command

/*ValueSetterGenerator*/
public static T Command<T>(this T control, System.Windows.Input.ICommand value) where T : Avalonia.Input.KeyBinding 
=> control._set(() => control.Command = value!);

/*BindFromExpressionSetterGenerator*/
public static T Command<T>(this T control, Func<System.Windows.Input.ICommand> func, Action<System.Windows.Input.ICommand>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Command<T>(this T control,System.Windows.Input.ICommand value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.CommandProperty, ps, () => control.Command = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Command<T>(this T control, IBinding binding) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Command<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Command<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Windows.Input.ICommand> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.CommandProperty, ps, () => control.Command = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // CommandParameter

/*ValueSetterGenerator*/
public static T CommandParameter<T>(this T control, System.Object value) where T : Avalonia.Input.KeyBinding 
=> control._set(() => control.CommandParameter = value!);

/*BindFromExpressionSetterGenerator*/
public static T CommandParameter<T>(this T control, Func<System.Object> func, Action<System.Object>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandParameterProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T CommandParameter<T>(this T control,System.Object value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.CommandParameterProperty, ps, () => control.CommandParameter = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T CommandParameter<T>(this T control, IBinding binding) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandParameterProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T CommandParameter<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.CommandParameterProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T CommandParameter<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Object> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.CommandParameterProperty, ps, () => control.CommandParameter = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Gesture

/*ValueSetterGenerator*/
public static T Gesture<T>(this T control, Avalonia.Input.KeyGesture value) where T : Avalonia.Input.KeyBinding 
=> control._set(() => control.Gesture = value!);

/*BindFromExpressionSetterGenerator*/
public static T Gesture<T>(this T control, Func<Avalonia.Input.KeyGesture> func, Action<Avalonia.Input.KeyGesture>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.GestureProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Gesture<T>(this T control,Avalonia.Input.KeyGesture value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.GestureProperty, ps, () => control.Gesture = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Gesture<T>(this T control, IBinding binding) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.GestureProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Gesture<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Input.KeyBinding 
   => control._set(Avalonia.Input.KeyBinding.GestureProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Gesture<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Input.KeyGesture> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Input.KeyBinding 
=> control._setEx(Avalonia.Input.KeyBinding.GestureProperty, ps, () => control.Gesture = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
