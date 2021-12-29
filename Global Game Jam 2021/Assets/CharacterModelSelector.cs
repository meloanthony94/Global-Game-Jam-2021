using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelSelector : MonoBehaviour
{
    [SerializeField]
    GameObject[] models;

    [SerializeField]
    FloatReference modelChoice;

    public GameObject[] Models { get => models; set => models = value; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateModel();
    }

    void UpdateModel()
    {
        Models[(int)modelChoice.Value].SetActive(true); 
    }
}
