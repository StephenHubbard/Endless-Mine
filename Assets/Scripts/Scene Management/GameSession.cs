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

    public bool isNewGame = false;
    public bool isLoadedGame = false;

    private void Awake()
    {
        Singleton();
    }

    void Start()
    {
    }

    public void addToSoldItemsArray(BlockInfo itemSold)
    {
        Block thisItem = itemSold.GetComponent<BlockInfo>().block;
        soldItems.Add(thisItem);

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
