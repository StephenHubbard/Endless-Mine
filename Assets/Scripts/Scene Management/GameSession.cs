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

    GameMenu gameMenu;

    private void Awake()
    {
        Singleton();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            var gameMenuInactive = Resources.FindObjectsOfTypeAll<GameMenu>();
            if (gameMenuInactive.Length > 0)
            {
                gameMenu = gameMenuInactive[0];
            }

            if (gameMenu.gameObject.activeInHierarchy)
            {
                gameMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                gameMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
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
