#nullable enable
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Avalonia.Markup.Declarative;
[global::System.CodeDom.Compiler.GeneratedCode("AvaloniaExtensionGenerator", "11.1.3.0")]
[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class AccessText_MarkupExtensions
{
//================= Properties ======================//

//================= Attached Properties ======================//

//================= Events ======================//

//================= Styles ======================//
 // ShowAccessKeyProperty

/*ValueStyleSetterGenerator*/
public static Style<T> AccessText_ShowAccessKey<T>(this Style<T> style, System.Boolean value) where T : Avalonia.Controls.Primitives.AccessText
=> style._addSetter(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, value);

/*BindingStyleSetterGenerator*/
public static Style<T> AccessText_ShowAccessKey<T>(this Style<T> style, IBinding binding) where T : Avalonia.Controls.Primitives.AccessText
=> style._addSetter(Avalonia.Controls.Primitives.AccessText.ShowAccessKeyProperty, binding);



}
