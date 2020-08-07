using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public CanvasGroup skyBackground;
    public CanvasGroup treesBackground;
    public CanvasGroup skyBackgroundDark;
    public CanvasGroup treesBackgroundDark;
    public CanvasGroup cavern;
    private PlayerMovement player;
    TimeOfDay timeOfDay;


    Coroutine currentActiveFade = null;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        timeOfDay = FindObjectOfType<TimeOfDay>();
    }

    private void Update()
    {
        checkTimeForBackground();
        CheckDepth();
    }

    private void checkTimeForBackground()
    {
        if (timeOfDay.day > .66)
        {
            FadeIn(skyBackgroundDark, timeOfDay.REAL_SECONDS_PER_INGAME_DAY * .25f);
            FadeIn(treesBackgroundDark, timeOfDay.REAL_SECONDS_PER_INGAME_DAY * .25f);
            FadeOut(skyBackground, timeOfDay.REAL_SECONDS_PER_INGAME_DAY * .25f);
            FadeOut(treesBackground, timeOfDay.REAL_SECONDS_PER_INGAME_DAY * .25f);
        }

        if (timeOfDay.day < .66)
        {
            FadeIn(skyBackground, 1f);
            FadeIn(treesBackground, 1f);
            FadeOut(skyBackgroundDark, 1f);
            FadeOut(treesBackgroundDark, 1f);
        }
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
