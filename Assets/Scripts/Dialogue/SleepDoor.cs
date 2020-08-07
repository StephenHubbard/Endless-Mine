using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherforge.dialogue
{
    public class SleepDoor : MonoBehaviour
    {
        [SerializeField] GameObject sleepButton;
        [SerializeField] GameObject shopButton;

        Vector2 startingPlayerPosition;

        PlayerMovement player;
        TimeOfDay timeOfDay;
        DayLight dayLight;

        private void Awake()
        {
            startingPlayerPosition = FindObjectOfType<PlayerMovement>().transform.position;
            timeOfDay = FindObjectOfType<TimeOfDay>();
            dayLight = FindObjectOfType<DayLight>();
        }

        void Start()
        {
        }

        public void showSleepButton()
        {
            sleepButton.SetActive(true);
            shopButton.SetActive(false);
        }

        public void endDay()
        {
            player = FindObjectOfType<PlayerMovement>();
            player.gameObject.transform.position = startingPlayerPosition;
            dayLight.lightSourceIntensity = .85f;
            dayLight.newDay();
            timeOfDay.newDay();
        }

    }
}
