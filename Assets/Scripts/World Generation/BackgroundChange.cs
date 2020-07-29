using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public CanvasGroup skyBackground;
    public CanvasGroup treesBackground;
    public CanvasGroup cavern;
    private PlayerMovement player;

    Coroutine currentActiveFade = null;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        CheckDepth();
    }

    private void CheckDepth()
    {
        if (player.transform.position.y < -10)
        {
            FadeIn(cavern, 2f);
            FadeOut(treesBackground, 2f);
            FadeOut(skyBackground, 2f);
        } else
        {
            FadeOut(cavern, 2f);
            FadeIn(treesBackground, 2f);
            FadeIn(skyBackground, 2f);
        }
    }

    public Coroutine FadeOut(CanvasGroup canvasGroup,  float time)
    {
        return Fade(canvasGroup, 0, time);
    }

    public Coroutine FadeIn(CanvasGroup canvasGroup, float time)
    {
        return Fade(canvasGroup, 1, time);
    }

    public Coroutine Fade(CanvasGroup canvasGroup, float target, float time)
    {
        if (currentActiveFade != null)
        {
            StopCoroutine(currentActiveFade);
        }
        currentActiveFade = StartCoroutine(FadeRoutine(canvasGroup, target, time));
        return currentActiveFade;
    }

    private IEnumerator FadeRoutine(CanvasGroup canvasGroup, float target, float time)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
            yield return null;
        }
    }
}
