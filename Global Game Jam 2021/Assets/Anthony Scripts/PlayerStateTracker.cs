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
    private Sprite playerAliveSprite = null;
    [SerializeField]
    private Sprite playerDeadSprite = null;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("PlayerDied", HandlePlayerDeadEvent);
    }

    private void HandlePlayerDeadEvent(object data)
    {
        int eventPlayerID = (int)data;

        if (eventPlayerID == playerId)
        {
            spriteRenderer.sprite = playerDeadSprite;
        }
    }
}
