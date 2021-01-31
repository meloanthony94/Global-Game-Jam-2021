using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<SpawnManagerScriptableObject> playerSpawns = new List<SpawnManagerScriptableObject>();
    [SerializeField]
    private List<GameObject> playerObjects = new List<GameObject>();

    [SerializeField]
    private SpawnManagerScriptableObject superFoodSpawns;
    [SerializeField]
    private List<GameObject> superFoodObjects = new List<GameObject>();
    private HashSet<int> superFoodPositions = new HashSet<int>();

    [SerializeField]
    private SpawnManagerScriptableObject baseFoodSpawns;
    [SerializeField]
    private List<GameObject> baseFoodObjects = new List<GameObject>();

    [SerializeField]
    private int numberOfSuperFood = 0;
    [SerializeField]
    private int numberOfBaseFood = 0;

    static Random rng = new Random();

    public List<GameObject> PlayerObjects { get => playerObjects; set => playerObjects = value; }

    void Start()
    {
        EventManager.StartListening("RespawnSuperFood", HandleRespawnSuperFoodEvent);
    }

    public void SpawnGameObjects(int numberOfPlayers)
    {
        SetPlayerSpawns(numberOfPlayers);
        SpawnFood();
    }

    private void SetPlayerSpawns(int numberOfPlayers)
    {
        Vector3[] playerPositions = playerSpawns[numberOfPlayers - 2].playerSpawnPoints;
        for (int i = 0; i < numberOfPlayers; i++)
        {
            PlayerObjects[i].transform.localPosition = playerPositions[i];
            PlayerObjects[i].SetActive(true);
        }
    }

    private void SpawnFood()
    {
        SpawnSuperFood();
        SpawnBaseFood();
    }

    public void SpawnSuperFood()
    {
        Debug.Assert(numberOfSuperFood <= superFoodObjects.Count, "Number of super food objects to spawn is greater than the number of objects available!");

        var randomIndicies = GetRandomIndicies(numberOfSuperFood);
        for (int i = 0; i < numberOfSuperFood; i++)
        {
            SuperFood.SuperFoodData data = new SuperFood.SuperFoodData(i, randomIndicies[i]);
            superFoodObjects[i].GetComponent<SuperFood>().Data = data;
            superFoodPositions.Add(data.position);

            superFoodObjects[i].transform.localPosition = superFoodSpawns.playerSpawnPoints[randomIndicies[i]];
            superFoodObjects[i].SetActive(true);
        }
    }

    public void HandleRespawnSuperFoodEvent(object data)
    {
        int superFoodID = (int)data;
        Debug.Log("Super food " + superFoodID.ToString() + " is respawning!");

        SuperFood.SuperFoodData superFoodData = superFoodObjects[superFoodID].GetComponent<SuperFood>().Data;
        superFoodPositions.Remove(superFoodData.position);

        int randomValue = Random.Range(0, numberOfSuperFood);
        StartCoroutine(GetRandomValue(superFoodPositions, randomValue, numberOfSuperFood));

        superFoodPositions.Add(randomValue);
        superFoodData.position = randomValue;

        superFoodObjects[superFoodID].transform.localPosition = superFoodSpawns.playerSpawnPoints[randomValue];
        superFoodObjects[superFoodID].SetActive(true);
    }

    public void SpawnBaseFood()
    {
        Debug.Assert(numberOfBaseFood < baseFoodObjects.Count, "Number of base food objects to spawn is greater than the number of objects available!");
        
        for (int i = 0; i < numberOfBaseFood; i++)
        {
            baseFoodObjects[i].transform.localPosition = baseFoodSpawns.playerSpawnPoints[i];
            baseFoodObjects[i].SetActive(true);
        }
    }

    private List<int> GetRandomIndicies(int count)
    {
        var result = new List<int>();
        var hash = new HashSet<int>();
        
        for (int i = 0; i < count; i++)
        {
            int randomValue = Random.Range(0, count - 1);
            StartCoroutine(GetRandomValue(hash, randomValue, count));
            hash.Add(randomValue);
            result.Add(randomValue);
        }

        return result;
    }

    public void TogglePlayer(int playerId, bool toggle)
    {
        PlayerObjects[playerId].SetActive(toggle);
    }

    private IEnumerator GetRandomValue(HashSet<int> hash, int randomValue, int count)
    {
        while (hash.Contains(randomValue))
        {
            randomValue = Random.Range(0, count - 1);

            yield return null;
        }
    }
}
