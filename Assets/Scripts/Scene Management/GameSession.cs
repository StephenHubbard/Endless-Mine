using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Netherforge.dialogue;

public class GameSession : MonoBehaviour
{

    int startSceneIndex;

    public int goldEarnedThisDay = 0;
    public int currentDay = 1;

    public List<Block> soldItems = new List<Block>();

    private void Awake()
    {
        Singleton();
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void addToSoldItemsArray(BlockInfo itemSold)
    {
        Block thisItem = itemSold.GetComponent<BlockInfo>().block;
        soldItems.Add(thisItem);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "NetherforgeMain")
        {
            goldEarnedThisDay = 0;
            currentDay += 1;
            soldItems.Clear();
        }
        if (scene.name == "EndOfDayScreen")
        {
            EndOfDayTally endOfDayTally = FindObjectOfType<EndOfDayTally>();
        }
    }

    private void Singleton()
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


}
