﻿//prevent from warning "Method 'OnPropertyChanged' do not invoke base.OnPropertyChanged" - OnPropertyChanged is abstract
#pragma warning disable AVA2001

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Avalonia.Markup.Declarative;

internal class ViewPropertyComputedState<TValue> : ViewPropertyComputedState, IObservable<TValue>, INotifyPropertyChanged
{
    public Func<TValue> GetterFunc { get; }
    public TValue Value => GetterFunc();

    public ViewPropertyComputedState(string? expressionString, Func<TValue> getterFunc)
    {
        GetterFunc = getterFunc;
        ExpressionString = expressionString;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public override void OnPropertyChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        NotifyObservers(Value);
    }

    private readonly List<IObserver<TValue>> _observers = [];

    public IDisposable Subscribe(IObserver<TValue> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    public void NotifyObservers(TValue value)
    {
        foreach (var observer in _observers)
            observer.OnNext(value);
    }

    private class Unsubscriber(ICollection<IObserver<TValue>> observers, IObserver<TValue> observer) : IDisposable
    {
        public void Dispose()
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }
}

internal class ViewPropertyComputedState<TControl, TValue> : ViewPropertyComputedState, IObservable<TValue>, IObserver<TValue>
    where TControl : AvaloniaObject

{
    private readonly IObservable<TValue>? _obs;
    private readonly TControl? _control;
    private readonly AvaloniaProperty<TValue>? _avaloniaProperty;
    public Action<TValue>? Setter { get; }
    public Action<TValue>? SetChangedHandler { get; }

    public TValue Value => GetterFunc();

    public Func<TValue> GetterFunc { get; }

    internal ViewPropertyComputedState(string? expressionString,
        Func<TValue> getterFunc,
        Action<TValue>? setChangedHandler,
        TControl? control,
        AvaloniaProperty<TValue>? avaloniaProperty)
    {
        _control = control;
        _avaloniaProperty = avaloniaProperty;
        SetChangedHandler = setChangedHandler;
        ExpressionString = expressionString;
        GetterFunc = getterFunc;

        if (control == null)
            return;

        UpdateControlValue();

        if (_avaloniaProperty != null)
        {
            control.Bind(_avaloniaProperty, this);

            if (setChangedHandler != null)
            {
                _obs = control.GetObservable(_avaloniaProperty);
                _obs.Subscribe(this);
            }
        }
    }

    internal ViewPropertyComputedState(string? expressionString,
        Action<TValue> setter,
        Func<TValue> getterFunc,
        Action<TValue>? setChangedHandler,
        TControl? control)
    {
        _control = control;
        Setter = setter;
        SetChangedHandler = setChangedHandler;
        ExpressionString = expressionString;
        GetterFunc = getterFunc;

        if (control == null)
            return;

        UpdateControlValue();
    }

    public override void OnPropertyChanged()
    {
        UpdateControlValue();
        NotifyObservers(Value);
    }

    private void UpdateControlValue()
    {
        if (_control == null)
            return;

        TValue newValue = GetterFunc();

        if (_avaloniaProperty != null)
        {
            if (!Equals(_control.GetValue(_avaloniaProperty), newValue))
            {
                _control.SetValue(_avaloniaProperty, newValue);
                SetChangedHandler?.Invoke(newValue);
            }
        }
        else
        {
            if (Setter != null)
            {
                Setter.Invoke(newValue);
                SetChangedHandler?.Invoke(newValue);
            }
        }
    }

    //private void UpdateControlValue()
    //{
    //    if (_control == null)
    //        return;

    //    if (_avaloniaProperty != null)
    //        _control.SetValue(_avaloniaProperty, Value);
    //    else
    //        Setter?.Invoke(GetterFunc());
    //}

    public void OnNext(TValue value)
    {
        if (Value == null && value == null)
            return;

        if (value != null && value.Equals(Value))
            return;

        SetChangedHandler?.Invoke(value);
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    #region IObservable implementation

    private readonly List<IObserver<TValue>> _observers = [];

    public IDisposable Subscribe(IObserver<TValue> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    public void NotifyObservers(TValue value)
    {
        foreach (var observer in _observers)
            observer.OnNext(value);
    }

    private class Unsubscriber(ICollection<IObserver<TValue>> observers, IObserver<TValue> observer) : IDisposable
    {
        public void Dispose()
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }

    #endregion

}

internal abstract class ViewPropertyComputedState
{
    internal string? ExpressionString { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ViewPropertyComputedState state &&
               ExpressionString == state.ExpressionString;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ExpressionString);
    }

    public abstract void OnPropertyChanged();
}