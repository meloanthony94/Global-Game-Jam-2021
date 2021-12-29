using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsDisplay : MonoBehaviour
{
    [SerializeField]
    MenuManager myMenuManager;

    [SerializeField]
    Image winningPlayerOverlay;

    [SerializeField]
    Sprite[] playerNumberSprites;

    [SerializeField]
    GameObject[] characterCards;

    [SerializeField]
    FloatReference[] PlayerSpriteChoices;

    // Start is called before the first frame update
    void Start()
    {
        int index = myMenuManager.WinningPlayer;
        
        //(int)PlayerSpriteChoices[myMenuManager.WinningPlayer].Value;

        winningPlayerOverlay.sprite = playerNumberSprites[index];

       characterCards[(int)PlayerSpriteChoices[index].Value].SetActive(true);
    }
}
