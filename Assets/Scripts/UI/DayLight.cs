using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayLight : MonoBehaviour
{
    private Light2D lightSource;
    private float timeOfDayFloat;
    private float lightSourceIntensity = .85f;
    private float lightSourceIntensityClamped;

    void Awake()
    {
        lightSource = GetComponent<Light2D>();
    }

    void Update()
    {
        timeOfDayFloat = FindObjectOfType<TimeOfDay>().day;
        if (timeOfDayFloat > .666f)
        {
            lightSourceIntensity -= Time.deltaTime / 4.8f;
            lightSourceIntensityClamped = Mathf.Clamp(lightSourceIntensity, 0f, 1f);
            lightSource.intensity = lightSourceIntensityClamped;

            if (lightSourceIntensityClamped < .85f)
            {
                // hacky way to fix light layering bug with torches on top level
                gameObject.SetActive(false);
                gameObject.SetActive(true);
            }
        }

    }
}
