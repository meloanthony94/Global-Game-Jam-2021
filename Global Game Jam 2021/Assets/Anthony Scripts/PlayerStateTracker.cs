using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateTracker : MonoBehaviour
{
    [SerializeField]
    private int playerId = -1;

    [SerializeField]
    private Image spriteRenderer = null;

    [SerializeField]
    private Image screamLevelSpriteRenderer = null;

    [SerializeField]
    private Sprite playerAliveSprite = null;
    [SerializeField]
    private Sprite playerDeadSprite = null;

    [SerializeField]
    private List<Sprite> screamLevelSprites = new List<Sprite>();

    private int screanLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("PlayerDied", HandlePlayerDeadEvent);
        EventManager.StartListening("ScreamLevelChanged", HandleScreamLevelChangedEvent);
        EventManager.StartListening("Scream", HandleScreamEvent);
    }

    private void HandlePlayerDeadEvent(object data)
    {
        int eventPlayerID = (int)data;

        if (eventPlayerID == playerId)
        {
            spriteRenderer.sprite = playerDeadSprite;
        }
    }

    private void HandleScreamLevelChangedEvent(object data)
    {
        int eventPlayerID = (int)data;

        if (eventPlayerID == playerId)
        {
            if ((screanLevelIndex + 1) < screamLevelSprites.Count)
            {
                screanLevelIndex++;
                screamLevelSpriteRenderer.sprite = screamLevelSprites[screanLevelIndex];
            }
        }
    }

    private void HandleScreamEvent(object data)
    {
        int eventPlayerID = (int)data;

        if (eventPlayerID == playerId)
        {
            screanLevelIndex = 0;
            screamLevelSpriteRenderer.sprite = screamLevelSprites[screanLevelIndex];
        }
    }
}
