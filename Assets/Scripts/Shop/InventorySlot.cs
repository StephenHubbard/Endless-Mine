using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public int amountInSlot = 0;
    TextMeshProUGUI amountText;
    public bool isOccupied = false;
    public ScriptableObject thisBlock;


    private void Awake()
    {
        amountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        updateAmountInSlot();
        isEmpty();
    }

    public void isEmpty()
    {
        if (!isOccupied)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {

    }

    public void updateAmountInSlot()
    {
        amountText.text = amountInSlot.ToString();
        if (amountInSlot == 0)
        {
            isOccupied = false;
            isEmpty();
        }
    }

    
}
