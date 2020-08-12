using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextButton : MonoBehaviour
{

    [SerializeField] GameObject EndOfDayCanvas;
    [SerializeField] GameObject UICanvas;

    TimeOfDay timeOfDay;
    DayLight dayLight;
    GameSession gameSession;
    EndOfDayTally endOfDayTally;
    EnemySpawns enemySpawns;


    private void Awake()
    {
        timeOfDay = FindObjectOfType<TimeOfDay>();
        dayLight = FindObjectOfType<DayLight>();
        gameSession = FindObjectOfType<GameSession>();
        endOfDayTally = FindObjectOfType<EndOfDayTally>();
        enemySpawns = FindObjectOfType<EnemySpawns>();

    }

    public void loadNextDay()
    {
        enemySpawns.NewDaySpawnEnemies();
        timeOfDay.day = 0.33333f;
        dayLight.lightSourceIntensity = .85f;
        gameSession.goldEarnedThisDay = 0;
        gameSession.soldItems.Clear();
        gameSession.currentDay += 1;
        endOfDayTally.endDayBool = false;
        endOfDayTally.resetSoldObjects();
        EndOfDayCanvas.SetActive(false);
        UICanvas.SetActive(true);
    }
}
