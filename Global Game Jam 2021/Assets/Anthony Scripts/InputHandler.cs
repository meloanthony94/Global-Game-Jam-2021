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

    [Header("Circle")]
    [SerializeField]
    ScriptableEvent[] PlayerCirclePressGroup;

    [Header("Square")]
    [SerializeField]
    ScriptableEvent[] PlayerSquarePressGroup;

    [Header("X")]
    [SerializeField]
    ScriptableEvent[] PlayerXPressGroup;

    [Header("Triangle")]
    [SerializeField]
    ScriptableEvent[] PlayerTrianglePressGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControllerLocater();

        for (int i = 0; i < NUMPLAYERS; i++)
        {
            PlayerHorizontalAxisGroup[i].Value = Input.GetAxis("Player " + (i + 1) + " Horizontal");
            PlayerVerticalAxisGroup[i].Value = Input.GetAxis("Player " + (i + 1) + " Vertical");

            if (Input.GetButtonDown("Player " + (i + 1) + " circle"))
            {
                PlayerCirclePressGroup[i].Raise();
               // Debug.Log("Player " + i + " circle");
            }

        //    if (Input.GetButtonDown("Player " + (i + 1) + " x"))
        //    {
        //        PlayerXPressGroup[i].Raise();
        //    }

            if (Input.GetButtonDown("Player " + (i + 1) + " triangle"))
            {
                PlayerTrianglePressGroup[i].Raise();
            }

            if (Input.GetButtonDown("Player " + (i + 1) + " square"))
            {
                PlayerSquarePressGroup[i].Raise();
            }
        }

       if (Input.GetButtonDown("Player 1 x"))
       {
           PlayerXPressGroup[0].Raise();
          // Debug.Log("Player 1 x");
       }
      
       if (Input.GetButtonDown("Player 2 x"))
       {
           PlayerXPressGroup[1].Raise();
           // Debug.Log("Player 2 x");
        }

       if (Input.GetButtonDown("Player 3 x"))
       {
           PlayerXPressGroup[2].Raise();
           // Debug.Log("Player 3 x");
        }

       if (Input.GetButtonDown("Player 4 x"))
       {
           PlayerXPressGroup[3].Raise();
          //  Debug.Log("Player 4 x");
        }
    }

    void ControllerLocater()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] == "Wireless Controller")
                print(i);
            //print(Input.GetJoystickNames().Length);
            //print(Input.GetJoystickNames()[i]);
        }
    }
}
