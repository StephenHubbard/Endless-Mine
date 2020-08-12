using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfDayTally : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI dayText;

    public List<Block> soldItems = new List<Block>();

    GameSession gameSession;

    public bool endDayBool = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
        

    }

    private void Update()
    {
        gameSession = FindObjectOfType<GameSession>();
        soldItems = gameSession.soldItems;

        // Getting a buggy race condition between this script and the gameSession singleton
        if (soldItems.Count > 0 && endDayBool == false)
        {
            UpdateAllItemsSold();
            transparentAlpha();
            endDayBool = true;
        }
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

    public void resetSoldObjects()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<BlockInfo>().block = null;
            child.GetComponent<Image>().sprite = null;
            child.GetChild(0).GetComponent<AmountText>().amountInSlot = 0;
            child.GetComponent<CanvasGroup>().alpha = 0;
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
