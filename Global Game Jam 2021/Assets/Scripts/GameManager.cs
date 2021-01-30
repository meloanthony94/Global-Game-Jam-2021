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

        currentState = GameState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        Process();
    }

    private void SetGameState(GameState state)
    {
        Debug.Log("Game state set to " + state.ToString());
        currentState = state;
    }

    private void Process()
    {
        switch (currentState)
        {
            case GameState.NONE:
                return;
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

    public void StartGame()
    {
        numberOfActivePlayers = numberOfPlayers;
        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        spManager.SetPlayerSpawns(numberOfPlayers);
    }
}
