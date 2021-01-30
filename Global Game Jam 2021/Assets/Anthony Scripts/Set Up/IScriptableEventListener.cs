using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScriptableEventListener<T>
{
    void OnEventRaised(T item);
}
