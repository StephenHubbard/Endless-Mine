using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayLight : MonoBehaviour
{
    private Light2D lightSource;
    private float timeOfDayFloat;
    public float lightSourceIntensity = .85f;
    private float lightSourceIntensityClamped;
    TimeOfDay timeOfDay;

    void Awake()
    {
        lightSource = GetComponent<Light2D>();
        timeOfDay = FindObjectOfType<TimeOfDay>();
    }

    void Update()
    {
        if (FindObjectOfType<TimeOfDay>())
        {
            timeOfDayFloat = FindObjectOfType<TimeOfDay>().day;
        }
        if (timeOfDayFloat > .75f)
        {
            lightSourceIntensity -= Time.deltaTime / (timeOfDay.REAL_SECONDS_PER_INGAME_DAY * .25f);
            lightSourceIntensityClamped = Mathf.Clamp(lightSourceIntensity, 0f, 1f);
            lightSource.intensity = lightSourceIntensityClamped;

            if (lightSourceIntensityClamped < .85f)
            {
                // hacky way to fix light layering bug with torches on top level
                gameObject.SetActive(false);
                gameObject.SetActive(true);
            }
        }
        if (timeOfDayFloat < .75f)
        {
            lightSource.intensity = lightSourceIntensity;
        }
    }

    public void newDay()
    {
        lightSource.intensity = .85f;
    }
}
