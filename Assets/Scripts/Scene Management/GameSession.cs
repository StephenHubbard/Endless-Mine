using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    int startSceneIndex;

    public int goldEarnedThisDay = 0;
    public int currentDay = 1;

    public List<Block> soldItems = new List<Block>();

    GameSession gameSession;

    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<GameSession>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void addToSoldItemsArray(BlockInfo itemSold)
    {
        Block thisItem = itemSold.GetComponent<BlockInfo>().block;
        soldItems.Add(thisItem);

        foreach (Block item in soldItems)
        {
            //print(item.name);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "NetherforgeMain")
        {
            gameSession.goldEarnedThisDay = 0;
            gameSession.currentDay += 1;
        }
    }

    void Update()
    {
        
    }

    
}
