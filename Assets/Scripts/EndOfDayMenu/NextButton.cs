using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextButton : MonoBehaviour
{
    GameSession gameSession;

    private void Awake()
    {
    }

    public void loadNextDay()
    {
        gameSession = FindObjectOfType<GameSession>();
        SceneManager.LoadScene("NetherforgeMain");
    }
}
