using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numberOfPlayers = 0;
    public int NumberOfPlayers
    {
        get { return numberOfPlayers; }
        set { numberOfPlayers = value; }
    }

    private int numberOfActivePlayers = 0;

    private bool stateChanged = false;

    private enum GameState
    {
        NONE, 
        PLAY,
        PAUSE,
        END,
    };
    private GameState currentState;

    [SerializeField]
    private SpawnManager spManager = null;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("Pause", HandlePauseGameEvent);
        EventManager.StartListening("Resume", HandleResumeGameEvent);
        EventManager.StartListening("PlayerDied", HandlePlayerDeadEvent);
        EventManager.StartListening("StartGame", HandleStartGameEvent);

        SetGameState(GameState.NONE);
    }

    // Update is called once per frame
    void Update()
    {
        if (stateChanged)
        {
            stateChanged = false;
            Process();
        }
    }

    private void SetGameState(GameState state)
    {
        Debug.Log("Game state set to " + state.ToString());
        currentState = state;

        stateChanged = true;
    }

    private void Process()
    {
        switch (currentState)
        {
            case GameState.NONE:
                numberOfActivePlayers = numberOfPlayers = 4;
                break;
            case GameState.PLAY:
                if (numberOfActivePlayers == 1)
                {
                    SetGameState(GameState.END);
                }
                break;
            case GameState.PAUSE:
                return;
            case GameState.END:
                // Display win screen
                break;
            default:
                break;
        }
    }

    private void HandlePauseGameEvent(object data)
    {
        Debug.Log("Game Paused by Player " + data.ToString());

        SetGameState(GameState.PAUSE);
    }

    private void HandleResumeGameEvent(object data)
    {
        Debug.Log("Game Resumed by Player " + data.ToString());

        SetGameState(GameState.PLAY);
    }

    private void HandlePlayerDeadEvent(object data)
    {
        int playerID = (int)data;
        Debug.Log("Player " + playerID.ToString() + " has died!");

        spManager.TogglePlayer(playerID, false);

        numberOfActivePlayers--;
    }

    private void HandleStartGameEvent(object data)
    {
        Debug.Log("HandleStartGameEvent()");

        StartGame();
    }

    public void StartGame()
    {
        numberOfActivePlayers = numberOfPlayers;
        spManager.SpawnGameObjects(numberOfPlayers);

        SetGameState(GameState.PLAY);
    }
}
