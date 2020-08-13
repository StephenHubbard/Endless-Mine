using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    [SerializeField] TextMeshProUGUI progressText;
    GameSession gameSession;

    private float progress;

    private void Awake()
    {
    }

    public void StartNewGame(int sceneIndex)
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.isNewGame = true;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void LoadGame(int sceneIndex)
    {
        gameSession.isLoadedGame = true;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void DevModeGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        yield return null;

        //while (progress < 1f)
        //{
        //    float progress = Mathf.Clamp01(operation.progress / .9f);
        //    slider.value = progress;
        //    progressText.text = progress * 100f + "%";
        //    yield return null;
        //}

    }

}
