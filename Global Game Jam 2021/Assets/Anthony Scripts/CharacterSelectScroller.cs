using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScroller : MonoBehaviour
{
    [SerializeField]
    private FloatReference inputY;

    [SerializeField]
    private List<Sprite> characterSprites = new List<Sprite>();

    [SerializeField]
    private Image spriteRenderer;

    [SerializeField]
    private CharacterSelectCoordinator coordinator;

    [SerializeField]
    private int playerId = 0;

    [SerializeField]
    FloatReference characterSelection;

    private int highlightedObjectIndex = 0;

    private float timer = 0.0f;

    private void Start()
    {
        spriteRenderer.sprite = characterSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0f && coordinator.isPlayerReady(playerId) == false)
        {
            if (inputY.Value > 0.3f || inputY.Value < -0.3f)
            {
                highlightedObjectIndex += 1;
                if (highlightedObjectIndex >= characterSprites.Count)
                {
                    highlightedObjectIndex = -1;
                }

              
                if (highlightedObjectIndex >= 0 && highlightedObjectIndex < characterSprites.Count)
                {
                    SetChoice(highlightedObjectIndex);
                    spriteRenderer.sprite = characterSprites[highlightedObjectIndex];
                }

                timer = 0.3f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void SetChoice(float index)
    {
        characterSelection.Value = index;
    }
}
