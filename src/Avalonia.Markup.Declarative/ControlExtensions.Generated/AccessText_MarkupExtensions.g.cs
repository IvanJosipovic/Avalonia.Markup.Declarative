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
public static partial class AccessText_MarkupExtensions
{
//================= Properties ======================//
 // ShowAccessKey

/*ValueSetterGenerator*/
public static T ShowAccessKey<T>(this T control, System.Boolean value) where T : Avalonia.Controls.Primitives.AccessText 
=> control._set(() => control.ShowAccessKey = value!);

/*BindFromExpressionSetterGenerator*/
public static T ShowAccessKey<T>(this T control, Func<System.Boolean> func, Action<System.Boolean>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Primitives.AccessText 
   => control._set(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T ShowAccessKey<T>(this T control,System.Boolean value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Primitives.AccessText 
=> control._setEx(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, ps, () => control.ShowAccessKey = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T ShowAccessKey<T>(this T control, IBinding binding) where T : Avalonia.Controls.Primitives.AccessText 
   => control._set(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T ShowAccessKey<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Primitives.AccessText 
   => control._set(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T ShowAccessKey<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, System.Boolean> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Primitives.AccessText 
=> control._setEx(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, ps, () => control.ShowAccessKey = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Styles ======================//
 // ShowAccessKey

/*ValueStyleSetterGenerator*/
public static Style<T> ShowAccessKey<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Controls.Primitives.AccessText 
=> style._addSetter(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> ShowAccessKey<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Primitives.AccessText 
=> style._addSetter(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, binding);



}
