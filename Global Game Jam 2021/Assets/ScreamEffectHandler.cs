using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamEffectHandler : MonoBehaviour
{
    [SerializeField]
    FloatReference CharacterIndex;

    [SerializeField]
    float cooldDownGenerationTime = 1;

    float timer = 0;

    [SerializeField]
    Transform[] RingSets;

    [SerializeField]
    Transform[] rings;

    int ringIndex = 0;

    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer >= cooldDownGenerationTime)
            {
                if (ringIndex < rings.Length)
                {
                    rings[ringIndex].gameObject.SetActive(true);
                    ringIndex++;
                    timer = 0;
                }
                else
                {
                    isActive = false;
                }
            }
        }
    }

    void FillRingsList()
    {
        int size = RingSets[(int)CharacterIndex.Value].childCount;

        rings = new Transform[size];
        //rings = RingSets[(int)CharacterIndex.Value].GetComponentsInChildren<Transform>();

        for (int i = 0; i < size; i++)
        {
            rings[i] = RingSets[(int)CharacterIndex.Value].GetChild(i);
        }
    }

    public void ScreamActivate()
    {
        FillRingsList();

        isActive = true;
        ringIndex = 0;
        rings[ringIndex].gameObject.SetActive(true);
        ringIndex++;
    }
}
