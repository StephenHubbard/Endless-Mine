using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    int startSceneIndex;

    public int goldEarnedThisDay = 0;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "NetherforgeMain")
        {
            gameSession.goldEarnedThisDay = 0;
        }
    }

    void Update()
    {
        
    }

    
}
