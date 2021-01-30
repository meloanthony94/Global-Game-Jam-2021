﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject titleScreen = null;
    [SerializeField]
    private GameObject infoScreen = null;
    [SerializeField]
    private GameObject characterSelectScreen = null;
    [SerializeField]
    private GameObject pauseScreen = null;
    [SerializeField]
    private GameObject creditsScreen = null;
    [SerializeField]
    private GameObject gameScreen = null;
    [SerializeField]
    private GameObject resultsScreen = null;

    public void HandlePlayButtonClicked()
    {
        Debug.Log("Play button clicked");

        characterSelectScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void HandleInfoScreenButtonClicked()
    {
        Debug.Log("Info button clicked");

        infoScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void HandleExitInfoScreenButtonClicked()
    {
        Debug.Log("Exit info button clicked");

        titleScreen.SetActive(true);
        infoScreen.SetActive(false);
    }

    public void HandleCreditsScreenButtonClicked()
    {
        Debug.Log("Credits button clicked");

        creditsScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void HandleExitCreditsScreenButtonClicked()
    {
        Debug.Log("Exit credits button clicked");

        titleScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void HandleStartButtonClicked()
    {
        Debug.Log("Start button clicked");
        EventManager.TriggerEvent("StartGame", 0);

        gameScreen.SetActive(true);
        characterSelectScreen.SetActive(false);
    }

    public void HandleExitCharacterSelectScreenButtonClicked()
    {
        Debug.Log("Exit character select button clicked");

        titleScreen.SetActive(true);
        characterSelectScreen.SetActive(false);
    }
}
