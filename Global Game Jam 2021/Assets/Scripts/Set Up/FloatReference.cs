using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Refernce", menuName = "ScriptableObjects/Variables/Float Refernce")]
public class FloatReference : ScriptableObject
{
    [SerializeField]
    float value;

    public float Value { get => value; set => this.value = value; }
}
