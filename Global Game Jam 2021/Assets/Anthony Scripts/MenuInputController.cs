using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInputController : MonoBehaviour
{
    [SerializeField]
    private FloatReference inputY;
    [SerializeField]
    private FloatReference inputX;
    
    [SerializeField]
    private List<Button> buttonObjects = new List<Button>();

    private int highlightedObjectIndex = 0;

    private float timer = 0.0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0f)
        {
            if (inputX.Value > 0.3f || inputX.Value < -0.3f || inputY.Value > 0.3f || inputY.Value < -0.3f)
            {
                highlightedObjectIndex += 1;
                if (highlightedObjectIndex >= buttonObjects.Count)
                {
                    highlightedObjectIndex = -1;
                }

                if (highlightedObjectIndex >= 0 && highlightedObjectIndex < buttonObjects.Count)
                {
                    buttonObjects[highlightedObjectIndex].Select();
                    buttonObjects[highlightedObjectIndex].OnSelect(null);
                }

                timer = 0.3f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void PressSelectedButton()
    {
        Debug.Log("Button Pressed!");

        if (highlightedObjectIndex >= 0 && highlightedObjectIndex < buttonObjects.Count)
        {
            //buttonObjects[highlightedObjectIndex].Select();
           // buttonObjects[highlightedObjectIndex].OnSelect(null);
            buttonObjects[highlightedObjectIndex].onClick.Invoke();
        }
        //buttonObjects[highlightedObjectIndex].Invoke("OnClick", 0.1f);
    }
}
