using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterPicker : MonoBehaviour
{
    [SerializeField]
    CharacterSelectCoordinator myCoordinator;

    [SerializeField]
    int id = 0;

    [SerializeField]
    bool indicatorActive = false;

    [SerializeField]
    bool isReady = false;

    [SerializeField]
    FloatReference CharacterSelection;

    [SerializeField]
    FloatReference HorizontalAxis;

    [SerializeField]
    Image[] selectionIndicators;

    [SerializeField]
    Sprite hoverSprite;

    [SerializeField]
    Sprite readySprite;

    [SerializeField]
    float inputCooldownTime = 0.2f;

    [SerializeField]
    UnityEvent buttonHover;


    float inputTimer = 0;
    bool coolingDown = false;


    int currentSelection = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!coolingDown && indicatorActive && !isReady)
        {
            if (HorizontalAxis.Value > 0.3f)
            {
                selectionIndicators[currentSelection].enabled = false;

                currentSelection = (currentSelection + 1) % selectionIndicators.Length;

                selectionIndicators[currentSelection].enabled = true;

                coolingDown = true;

                buttonHover.Invoke();
            }
            else if (HorizontalAxis.Value < -0.3f)
            {
                selectionIndicators[currentSelection].enabled = false;

                currentSelection = ((currentSelection - 1) + selectionIndicators.Length) % selectionIndicators.Length;

                selectionIndicators[currentSelection].enabled = true;

                coolingDown = true;

                buttonHover.Invoke();
            }
        }
        else
        {
            inputTimer += Time.deltaTime;

            if (inputTimer >= inputCooldownTime)
            {
                inputTimer = 0;
                coolingDown = false;
            }
        }
    }

    public void Submit()
    {
        if (indicatorActive && !isReady)
        {
            isReady = true;
            selectionIndicators[currentSelection].sprite = readySprite;
            CharacterSelection.Value = currentSelection;
            myCoordinator.PlayerReadyPressed(id);
        }
        else
        {
            indicatorActive = true;
            selectionIndicators[currentSelection].enabled = true;
        }
    }

    public void Reset(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            //reset current spot
            selectionIndicators[currentSelection].sprite = hoverSprite;
            selectionIndicators[currentSelection].enabled = false;

            //reset to first character
            currentSelection = 0;
            selectionIndicators[currentSelection].enabled = true;

            indicatorActive = true;
            isReady = false;
            coolingDown = false;
        }
        else
        {
            selectionIndicators[currentSelection].sprite = hoverSprite;
            selectionIndicators[currentSelection].enabled = false;
            currentSelection = 0;

            indicatorActive = false;
            isReady = false;
            coolingDown = false;
        }

        CharacterSelection.Value = 0;
    }
}
