using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCoordinator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characterSlots = new List<GameObject>();
    [SerializeField]
    private List<GameObject> readyBanners = new List<GameObject>();

    public void Start()
    {
        EventManager.StartListening("ExitCharacterSelection", HandleExitCharacterScreenEvent);
    }

    public bool isPlayerReady(int playerId)
    {
        return readyBanners[playerId].activeInHierarchy;
    }
    
    public void Reset()
    {
        for (int i = 0; i < readyBanners.Count; i++)
        {
            readyBanners[i].SetActive(false);
        }
        for (int i = 0; i < characterSlots.Count; i++)
        {
            characterSlots[i].SetActive(false);
        }
    }

    public void HandleExitCharacterScreenEvent(object data)
    {
        Reset();
    }

    public void PlayerOnePressX()
    {
        if (readyBanners[0].activeInHierarchy == false)
        {
            readyBanners[0].SetActive(true);
        }
    }

    public void PlayerTwoPressX()
    {
        if (characterSlots[0].activeInHierarchy == false)
        {
            characterSlots[0].SetActive(true);
        }
        else if (readyBanners[1].activeInHierarchy == false)
        {
            readyBanners[1].SetActive(true);
        }
    }

    public void PlayerThreePressX()
    {
        if (characterSlots[1].activeInHierarchy == false)
        {
            characterSlots[1].SetActive(true);
        }
        else if (readyBanners[2].activeInHierarchy == false)
        {
            readyBanners[2].SetActive(true);
        }
    }

    public void PlayerFourPressX()
    {
        if (characterSlots[2].activeInHierarchy == false)
        {
            characterSlots[2].SetActive(true);
        }
        else if (readyBanners[3].activeInHierarchy == false)
        {
            readyBanners[3].SetActive(true);
        }
    }
}
