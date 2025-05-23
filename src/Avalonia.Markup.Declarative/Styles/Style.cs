﻿using Avalonia.Styling;
using System;

namespace Avalonia.Markup.Declarative;
/// <summary>
/// Typed style to support method chains with generic arguments
/// </summary>
/// <typeparam name="TControl">Type of the control that style will be applied to</typeparam>
public class Style<TControl> : Style, IRelativeStyle
    where TControl : StyledElement
{
    private Func<Selector, Selector> SelectorFunc { get; }

    /// <summary>
    /// Creates Style with added .OfType<typeparam name="TControl"></typeparam> selector
    /// </summary>
    public Style()
    {
        SelectorFunc = s => s.OfType<TControl>();
        if (ViewBuildContext.CurrentState != ViewBuildContextState.StyleBuilding)
            Selector = SelectorFunc(null!);
    }

    /// <summary>
    /// Creates Style with added .OfType<typeparam name="TControl"></typeparam> selector and use name="selectorFunc" to generate selector
    /// </summary>
    /// <param name="selectorFunc"></param>
    public Style(Func<Selector, Selector> selectorFunc)
    {
        SelectorFunc = s => selectorFunc(s.OfType<TControl>());
        //Prevent Selector generation from immediate call, since we need to apply base selectors from ascendant groups
        if (ViewBuildContext.CurrentState != ViewBuildContextState.StyleBuilding)
            Selector = SelectorFunc(null!);
    }

    public void UpdateSelector(Func<Selector, Selector>? baseSelectorFunc)
    {
        if (baseSelectorFunc != null)
            Selector = SelectorFunc(baseSelectorFunc(null!));
        else
            Selector = SelectorFunc(null!);
    }
}

internal interface IRelativeStyle : IStyle
{
    void UpdateSelector(Func<Selector, Selector>? baseSelectorFunc);
}