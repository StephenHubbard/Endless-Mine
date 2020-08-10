using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayTally : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalText;

    GameSession gameSession;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
        updateGoldEarned();
    }

    private void updateGoldEarned()
    {
        gameSession = FindObjectOfType<GameSession>();
        string goldEarnedString = gameSession.goldEarnedThisDay.ToString();
        totalText.text = "Total: " + goldEarnedString + " G";
    }
}
