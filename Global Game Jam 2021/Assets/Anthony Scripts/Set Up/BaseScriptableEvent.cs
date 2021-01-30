using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseScriptableEvent<T> : ScriptableObject
{
    //private List<EventListener> listeners =
    // new List<EventListener>();

    private List<IScriptableEventListener<T>> listeners = new List<IScriptableEventListener<T>>();

    public void Raise(T value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(IScriptableEventListener<T> listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(IScriptableEventListener<T> listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
