using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfDayTally : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI dayText;

    public List<Block> soldItems = new List<Block>();


    GameSession gameSession;

    private void Awake()
    {
    }

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        soldItems = gameSession.soldItems;
        UpdateAllItemsSold();
        transparentAlpha();
    }

    private void Update()
    {
        updateGoldEarned();
        updateCurrentDay();
    }

    private void UpdateAllItemsSold()
    {
        foreach (Block item in soldItems)
        {
            updateEachItem(item);
        }
    }

    public void updateEachItem(Block item)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<BlockInfo>().block != null && child.GetComponent<BlockInfo>().block.name == item.name)
            {
                child.GetChild(0).GetComponent<AmountText>().amountInSlot += 1;
                child.GetComponent<CanvasGroup>().alpha = 1;
                return;
            }
            else if (child.GetComponent<BlockInfo>().block == null)
            {
                child.GetComponent<BlockInfo>().block = item;
                child.GetComponent<Image>().sprite = item.sprite;
                child.GetChild(0).GetComponent<AmountText>().amountInSlot += 1;
                child.GetComponent<CanvasGroup>().alpha = 1;
                return;
            }
            else
            {
            }
        }
    }

    private void transparentAlpha()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<BlockInfo>().block == null)
            {
                child.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    private void updateGoldEarned()
    {
        string goldEarnedString = gameSession.goldEarnedThisDay.ToString();
        totalText.text = "Total: " + goldEarnedString + " G";
    }

    private void updateCurrentDay()
    {
        string currentDay = gameSession.currentDay.ToString();
        dayText.text = "Day " + currentDay;
    }
}
