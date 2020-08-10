using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Netherforge.dialogue;


public class TimeOfDay : MonoBehaviour
{
    public TextMeshProUGUI timeOfDayText;

    // must change value here and inspector
    public float REAL_SECONDS_PER_INGAME_DAY = 200f;

    public float day;

    private float hoursPerDay = 24f;
    private float minutesPerHour = 60f;

    BackgroundChange backgroundChange;
    DialogueManager dialogueManager;

    private void Awake()
    {
        day += 0.33333f;
        backgroundChange = FindObjectOfType<BackgroundChange>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        UpdateTime();
        EndOfDay();
        
    }

    public void newDay()
    {
        day = 0.33333f;

    }

    private void EndOfDay()
    {
        if (day >= 1f)
        {
            dialogueManager.GoToSleep();
        }
    }

    private void UpdateTime()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        string hoursStringAM = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string hoursStringPM = Mathf.Floor(dayNormalized * hoursPerDay - 12).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        if (day > .5f && day < .541666f)
        {
            timeOfDayText.text = hoursStringAM + ":" + minutesString + " PM";
        }
        else if (day < .54166f)
        {
            timeOfDayText.text = hoursStringAM + ":" + minutesString + " AM";
        }
        else
        {
            timeOfDayText.text = hoursStringPM + ":" + minutesString + " PM";
        }
    }

    
}

