using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectCoordinator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characterSlots = new List<GameObject>();
    [SerializeField]
    private List<GameObject> readyBanners = new List<GameObject>();

    [SerializeField]
    private GameObject startButton = new GameObject();

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
        startButton.SetActive(false);
    }

    public void HandleExitCharacterScreenEvent(object data)
    {
        Reset();
    }

    public void PlayerOnePressX()
    {
        PlayerReadyPressed(0);
    }

    public void PlayerTwoPressX()
    {
        if (characterSlots[0].activeInHierarchy == false)
        {
            characterSlots[0].SetActive(true);
        }
        else
        {
            PlayerReadyPressed(1);
        }
    }

    public void PlayerThreePressX()
    {
        if (characterSlots[1].activeInHierarchy == false)
        {
            characterSlots[1].SetActive(true);
        }
        else
        {
            PlayerReadyPressed(2);
        }
    }

    public void PlayerFourPressX()
    {
        if (characterSlots[2].activeInHierarchy == false)
        {
            characterSlots[2].SetActive(true);
        }
        else
        {
            PlayerReadyPressed(3);
        }
    }

    private void PlayerReadyPressed(int playerId)
    {
        if (readyBanners[playerId].activeInHierarchy == false)
        {
            EventManager.TriggerEvent("PlayerReady", playerId);
            readyBanners[playerId].SetActive(true);
            CheckShouldEnableStartButton();
        }
    }

    private void CheckShouldEnableStartButton()
    {
        int numberOfActivePlayers = 1;
        for (int i = 0; i < characterSlots.Count; i++)
        {
            if (characterSlots[i].activeInHierarchy)
            {
                numberOfActivePlayers++;
            }
        }

        int numberOfPlayersReady = 0;
        for (int i = 0; i < readyBanners.Count; i++)
        {
            if (readyBanners[i].activeInHierarchy)
            {
                numberOfPlayersReady++;
            }
        }

        if (numberOfActivePlayers > 1)
        {
            if ((numberOfPlayersReady == numberOfActivePlayers))
            {
                EventManager.TriggerEvent("NumberOfPlayers", numberOfActivePlayers);
                startButton.SetActive(true);
            }
            else
            {
                startButton.SetActive(false);
            }
        }
    }
}
