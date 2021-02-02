using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsDisplay : MonoBehaviour
{
    [SerializeField]
    MenuManager myMenuManager;

    [SerializeField]
    Image winningPlayerImage;

    [SerializeField]
    List<Sprite> characterSprites;

    [SerializeField]
    FloatReference[] PlayerSpriteChoices;

    // Start is called before the first frame update
    void Start()
    {
        winningPlayerImage.sprite = characterSprites[(int)PlayerSpriteChoices[myMenuManager.WinningPlayer].Value];
    }
}
