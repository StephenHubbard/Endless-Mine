using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    SavingSystemInput savingSystemInput;

    private void Awake()
    {
        savingSystemInput = FindObjectOfType<SavingSystemInput>();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void SaveGame()
    {
        savingSystemInput.SaveGame();
    }

    public void LoadGame()
    {
        savingSystemInput.LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
