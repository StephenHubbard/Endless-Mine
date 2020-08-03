using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeOfDay : MonoBehaviour
{
    public TextMeshProUGUI timeOfDayText;

    //private const float REAL_SECONDS_PER_INGAME_DAY = 1440f;
    private const float REAL_SECONDS_PER_INGAME_DAY = 14.4f;

    public float day;

    private float hoursPerDay = 24f;
    private float minutesPerHour = 60f;

    private void Awake()
    {
        day += 0.33333f;
    }

    private void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeOfDayText.text = hoursString + ":" + minutesString + " AM";
    }
}

