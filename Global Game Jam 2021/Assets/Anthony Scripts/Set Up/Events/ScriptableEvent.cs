using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Scriptable Event", menuName = "ScriptableObjects/Event/Scriptable Event")]
public class ScriptableEvent : BaseScriptableEvent<Void>
{
    public void Raise()
    {
        Raise(new Void());
    }
}
 