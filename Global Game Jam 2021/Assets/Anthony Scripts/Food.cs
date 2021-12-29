using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour, IFood
{
    [SerializeField]
    private int powerValue;
    public int PowerValue
    {
        get { return powerValue; }
        set { powerValue = value; }
    }

    [SerializeField]
    UnityEvent consumeEvent;

    public virtual void Consume()
    {
        consumeEvent.Invoke();
    }
}
