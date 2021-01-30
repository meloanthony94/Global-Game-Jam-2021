using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    [SerializeField]
    private int powerValue;
    public int PowerValue
    {
        get { return powerValue; }
        set { powerValue = value; }
    }

    public virtual void Consume()
    {

    }
}
