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
public static partial class Image_MarkupExtensions
{
//================= Properties ======================//
 // Source

/*ValueSetterGenerator*/
public static T Source<T>(this T control, Avalonia.Media.IImage value) where T : Avalonia.Controls.Image 
=> control._set(() => control.Source = value!);

/*BindFromExpressionSetterGenerator*/
public static T Source<T>(this T control, Func<Avalonia.Media.IImage> func, Action<Avalonia.Media.IImage>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.SourceProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Source<T>(this T control,Avalonia.Media.IImage value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.SourceProperty, ps, () => control.Source = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Source<T>(this T control, IBinding binding) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.SourceProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Source<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.SourceProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Source<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.IImage> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.SourceProperty, ps, () => control.Source = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // BlendMode

/*ValueSetterGenerator*/
public static T BlendMode<T>(this T control, Avalonia.Media.Imaging.BitmapBlendingMode value) where T : Avalonia.Controls.Image 
=> control._set(() => control.BlendMode = value!);

/*BindFromExpressionSetterGenerator*/
public static T BlendMode<T>(this T control, Func<Avalonia.Media.Imaging.BitmapBlendingMode> func, Action<Avalonia.Media.Imaging.BitmapBlendingMode>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.BlendModeProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T BlendMode<T>(this T control,Avalonia.Media.Imaging.BitmapBlendingMode value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.BlendModeProperty, ps, () => control.BlendMode = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T BlendMode<T>(this T control, IBinding binding) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.BlendModeProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T BlendMode<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.BlendModeProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T BlendMode<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Imaging.BitmapBlendingMode> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.BlendModeProperty, ps, () => control.BlendMode = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Stretch

/*ValueSetterGenerator*/
public static T Stretch<T>(this T control, Avalonia.Media.Stretch value) where T : Avalonia.Controls.Image 
=> control._set(() => control.Stretch = value!);

/*BindFromExpressionSetterGenerator*/
public static T Stretch<T>(this T control, Func<Avalonia.Media.Stretch> func, Action<Avalonia.Media.Stretch>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T Stretch<T>(this T control,Avalonia.Media.Stretch value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.StretchProperty, ps, () => control.Stretch = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T Stretch<T>(this T control, IBinding binding) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T Stretch<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T Stretch<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Stretch> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.StretchProperty, ps, () => control.Stretch = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // StretchDirection

/*ValueSetterGenerator*/
public static T StretchDirection<T>(this T control, Avalonia.Media.StretchDirection value) where T : Avalonia.Controls.Image 
=> control._set(() => control.StretchDirection = value!);

/*BindFromExpressionSetterGenerator*/
public static T StretchDirection<T>(this T control, Func<Avalonia.Media.StretchDirection> func, Action<Avalonia.Media.StretchDirection>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchDirectionProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static T StretchDirection<T>(this T control,Avalonia.Media.StretchDirection value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.StretchDirectionProperty, ps, () => control.StretchDirection = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static T StretchDirection<T>(this T control, IBinding binding) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchDirectionProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static T StretchDirection<T>(this T control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null) where T : Avalonia.Controls.Image 
   => control._set(Avalonia.Controls.Image.StretchDirectionProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static T StretchDirection<TValue,T>(this T control, TValue value, FuncValueConverter<TValue, Avalonia.Media.StretchDirection> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null) where T : Avalonia.Controls.Image 
=> control._setEx(Avalonia.Controls.Image.StretchDirectionProperty, ps, () => control.StretchDirection = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



//================= Styles ======================//
 // Source

/*ValueStyleSetterGenerator*/
public static Style<T> Source<T>(this Style<T> style, Avalonia.Media.IImage value) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.SourceProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> Source<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.SourceProperty, binding);


 // BlendMode

/*ValueStyleSetterGenerator*/
public static Style<T> BlendMode<T>(this Style<T> style, Avalonia.Media.Imaging.BitmapBlendingMode value) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.BlendModeProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> BlendMode<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.BlendModeProperty, binding);


 // Stretch

/*ValueStyleSetterGenerator*/
public static Style<T> Stretch<T>(this Style<T> style, Avalonia.Media.Stretch value) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.StretchProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> Stretch<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.StretchProperty, binding);


 // StretchDirection

/*ValueStyleSetterGenerator*/
public static Style<T> StretchDirection<T>(this Style<T> style, Avalonia.Media.StretchDirection value) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.StretchDirectionProperty!, value!);

/*BindingStyleSetterGenerator*/
public static Style<T> StretchDirection<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Image 
=> style._addSetter(Avalonia.Controls.Image.StretchDirectionProperty, binding);



}
