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
public static partial class GeometryDrawing_MarkupExtensions
{
//================= Properties ======================//
 // Geometry

/*ValueSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Geometry(this Avalonia.Media.GeometryDrawing control, Avalonia.Media.Geometry value)  
=> control._set(() => control.Geometry = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Geometry(this Avalonia.Media.GeometryDrawing control, Func<Avalonia.Media.Geometry> func, Action<Avalonia.Media.Geometry>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.GeometryDrawing.GeometryProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Geometry(this Avalonia.Media.GeometryDrawing control,Avalonia.Media.Geometry value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.GeometryProperty, ps, () => control.Geometry = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Geometry(this Avalonia.Media.GeometryDrawing control, IBinding binding)  
   => control._set(Avalonia.Media.GeometryDrawing.GeometryProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Geometry(this Avalonia.Media.GeometryDrawing control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.GeometryDrawing.GeometryProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Geometry<TValue>(this Avalonia.Media.GeometryDrawing control, TValue value, FuncValueConverter<TValue, Avalonia.Media.Geometry> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.GeometryProperty, ps, () => control.Geometry = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Brush

/*ValueSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Brush(this Avalonia.Media.GeometryDrawing control, Avalonia.Media.IBrush value)  
=> control._set(() => control.Brush = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Brush(this Avalonia.Media.GeometryDrawing control, Func<Avalonia.Media.IBrush> func, Action<Avalonia.Media.IBrush>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.GeometryDrawing.BrushProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Brush(this Avalonia.Media.GeometryDrawing control,Avalonia.Media.IBrush value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.BrushProperty, ps, () => control.Brush = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Brush(this Avalonia.Media.GeometryDrawing control, IBinding binding)  
   => control._set(Avalonia.Media.GeometryDrawing.BrushProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Brush(this Avalonia.Media.GeometryDrawing control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.GeometryDrawing.BrushProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Brush<TValue>(this Avalonia.Media.GeometryDrawing control, TValue value, FuncValueConverter<TValue, Avalonia.Media.IBrush> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.BrushProperty, ps, () => control.Brush = converter.TryConvert(value)!, bindingMode, converter, bindingSource);


 // Pen

/*ValueSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Pen(this Avalonia.Media.GeometryDrawing control, Avalonia.Media.IPen value)  
=> control._set(() => control.Pen = value!);

/*BindFromExpressionSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Pen(this Avalonia.Media.GeometryDrawing control, Func<Avalonia.Media.IPen> func, Action<Avalonia.Media.IPen>? onChanged = null, [CallerArgumentExpression(nameof(func))] string? expression = null)  
   => control._set(Avalonia.Media.GeometryDrawing.PenProperty!, func, onChanged, expression);

/*MagicalSetterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Pen(this Avalonia.Media.GeometryDrawing control,Avalonia.Media.IPen value, BindingMode? bindingMode = null, IValueConverter? converter = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.PenProperty, ps, () => control.Pen = value!, bindingMode, converter, bindingSource);

/*BindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Pen(this Avalonia.Media.GeometryDrawing control, IBinding binding)  
   => control._set(Avalonia.Media.GeometryDrawing.PenProperty, binding);

/*AvaloniaPropertyBindSetterGenerator*/
public static Avalonia.Media.GeometryDrawing Pen(this Avalonia.Media.GeometryDrawing control, AvaloniaProperty avaloniaProperty, BindingMode? bindingMode = null, IValueConverter? converter = null, ViewBase? overrideView = null)  
   => control._set(Avalonia.Media.GeometryDrawing.PenProperty, avaloniaProperty, bindingMode, converter, overrideView);

/*MagicalSetterWithConverterGenerator*/
[Obsolete]
public static Avalonia.Media.GeometryDrawing Pen<TValue>(this Avalonia.Media.GeometryDrawing control, TValue value, FuncValueConverter<TValue, Avalonia.Media.IPen> converter, BindingMode? bindingMode = null, object? bindingSource = null, [CallerArgumentExpression(nameof(value))] string? ps = null)  
=> control._setEx(Avalonia.Media.GeometryDrawing.PenProperty, ps, () => control.Pen = converter.TryConvert(value)!, bindingMode, converter, bindingSource);



}
