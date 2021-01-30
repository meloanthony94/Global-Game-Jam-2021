using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseScriptableEventListener<T, E, UER> : MonoBehaviour,
    IScriptableEventListener<T> where E : BaseScriptableEvent<T> where UER : UnityEvent<T>
{
    [SerializeField]
    E scriptableEvent;

    public E ScriptableEvent { get => scriptableEvent; set => scriptableEvent = value; }

    [SerializeField]
    UER unityEventResponse;

    private void OnEnable()
    {
        if (scriptableEvent == null)
            return;

        scriptableEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (scriptableEvent == null)
            return;

        scriptableEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T value)
    {
        if (unityEventResponse != null)
        {
            unityEventResponse.Invoke(value);
        }
    }
}
