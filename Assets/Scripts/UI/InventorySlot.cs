using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public int amountInSlot = 0;
    TextMeshProUGUI amountText;
    public bool isOccupied = false;


    private void Awake()
    {
        amountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        updateAmountInSlot();
    }

    void Update()
    {

    }

    public void updateAmountInSlot()
    {
        amountText.text = amountInSlot.ToString();
    }

    
}
