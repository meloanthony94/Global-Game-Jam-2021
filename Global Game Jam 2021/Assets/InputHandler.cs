using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    const int NUMPLAYERS = 4;

    [Header("Analog Stick Axis")]
    [SerializeField]
    FloatReference[] PlayerHorizontalAxisGroup;
    [SerializeField]
    FloatReference[] PlayerVerticalAxisGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NUMPLAYERS; i++)
        {
            PlayerHorizontalAxisGroup[i].Value = Input.GetAxis("Player " + (i + 1) + " Horizontal");
            PlayerVerticalAxisGroup[i].Value = Input.GetAxis("Player " + (i + 1) + " Vertical");
        }

        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] == "Wireless Controller")
                print(i);

            //print(Input.GetJoystickNames().Length);
            //print(Input.GetJoystickNames()[i]);
        }
    }
}
