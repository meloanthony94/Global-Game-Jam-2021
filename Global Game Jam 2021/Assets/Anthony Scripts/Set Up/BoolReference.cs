using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool Refernce", menuName = "ScriptableObjects/Variables/Bool Refernce")]
public class BoolReference : ScriptableObject
{
    [SerializeField]
    bool value;

    public bool Value { get => value; set => this.value = value; }
}
