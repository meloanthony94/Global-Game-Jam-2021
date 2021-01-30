using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
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
