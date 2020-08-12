using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Netherforge.dialogue
{
    public class SleepDoor : MonoBehaviour
    {
        [SerializeField] GameObject sleepButton;
        [SerializeField] GameObject shopButton;
        [SerializeField] GameObject EndOfDayCanvas;
        [SerializeField] GameObject UICanvas;

        Vector2 startingPlayerPosition;

        PlayerMovement player;
        TimeOfDay timeOfDay;
        DayLight dayLight;
        GameSession gameSession;

        private void Awake()
        {
            startingPlayerPosition = FindObjectOfType<PlayerMovement>().transform.position;
            timeOfDay = FindObjectOfType<TimeOfDay>();
            dayLight = FindObjectOfType<DayLight>();
            gameSession = FindObjectOfType<GameSession>();
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
            
            EndOfDayCanvas.SetActive(true);
            UICanvas.SetActive(false);
        }

    }
}
