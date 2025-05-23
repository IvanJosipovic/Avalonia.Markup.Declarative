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
public static partial class ButtonSpinner_MarkupExtensions
{
//================= Properties ======================//
 // AllowSpin

/*ValueSetterGenerator*/
public static T AllowSpin<T>(this T control, System.Boolean value) where T : Avalonia.Controls.ButtonSpinner 
=> control._set(() => control.AllowSpin = value!);

/*BindFromExpressionSetterGenerator*/
public static T AllowSpin<T>(this T control, Func<System.Boolean> func, Action<System.Boolean>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.AllowSpinProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T AllowSpin<T>(this T control,System.Boolean value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.AllowSpinProperty, ps, () => control.AllowSpin = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T AllowSpin<T>(this T control, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.AllowSpinProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T AllowSpin<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.AllowSpinProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T AllowSpin<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Boolean> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.AllowSpinProperty, ps, () => control.AllowSpin = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // ShowButtonSpinner

/*ValueSetterGenerator*/
public static T ShowButtonSpinner<T>(this T control, System.Boolean value) where T : Avalonia.Controls.ButtonSpinner 
=> control._set(() => control.ShowButtonSpinner = value!);

/*BindFromExpressionSetterGenerator*/
public static T ShowButtonSpinner<T>(this T control, Func<System.Boolean> func, Action<System.Boolean>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T ShowButtonSpinner<T>(this T control,System.Boolean value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty, ps, () => control.ShowButtonSpinner = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T ShowButtonSpinner<T>(this T control, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T ShowButtonSpinner<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T ShowButtonSpinner<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Boolean> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty, ps, () => control.ShowButtonSpinner = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // ButtonSpinnerLocation

/*ValueSetterGenerator*/
public static T ButtonSpinnerLocation<T>(this T control, Avalonia.Controls.Location value) where T : Avalonia.Controls.ButtonSpinner 
=> control._set(() => control.ButtonSpinnerLocation = value!);

/*BindFromExpressionSetterGenerator*/
public static T ButtonSpinnerLocation<T>(this T control, Func<Avalonia.Controls.Location> func, Action<Avalonia.Controls.Location>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T ButtonSpinnerLocation<T>(this T control,Avalonia.Controls.Location value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty, ps, () => control.ButtonSpinnerLocation = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T ButtonSpinnerLocation<T>(this T control, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T ButtonSpinnerLocation<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.ButtonSpinner 
   => control._set(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T ButtonSpinnerLocation<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Controls.Location> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.ButtonSpinner 
=> control._setEx(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty, ps, () => control.ButtonSpinnerLocation = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Styles ======================//
 // AllowSpin

/*ValueStyleSetterGenerator*/
public static Style<T> AllowSpin<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.AllowSpinProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> AllowSpin<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.AllowSpinProperty, binding);


 // ShowButtonSpinner

/*ValueStyleSetterGenerator*/
public static Style<T> ShowButtonSpinner<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> ShowButtonSpinner<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.ShowButtonSpinnerProperty, binding);


 // ButtonSpinnerLocation

/*ValueStyleSetterGenerator*/
public static Style<T> ButtonSpinnerLocation<T>(this Style<T> style, Avalonia.Controls.Location value) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> ButtonSpinnerLocation<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.ButtonSpinner 
=> style._addSetter(Avalonia.Controls.ButtonSpinner.ButtonSpinnerLocationProperty, binding);



}
