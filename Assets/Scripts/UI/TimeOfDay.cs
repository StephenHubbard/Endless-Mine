using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeOfDay : MonoBehaviour
{
    public TextMeshProUGUI timeOfDayText;

    // must change value here and inspector
    public float REAL_SECONDS_PER_INGAME_DAY = 600f;

    public float day;

    private float hoursPerDay = 24f;
    private float minutesPerHour = 60f;

    BackgroundChange backgroundChange;

    

    private void Awake()
    {
        day += 0.33333f;
        backgroundChange = FindObjectOfType<BackgroundChange>();
    }

    private void Update()
    {
        UpdateTime();
        EndOfDay();
    }

    private void EndOfDay()
    {
        if (day >= 1f)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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

