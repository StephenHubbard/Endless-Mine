using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour, IPointerClickHandler
{
    InventorySlot inventorySlot;
    CurrentGold currentGold;
    public GameObject shopWindow;

    private void Awake()
    {
        currentGold = FindObjectOfType<CurrentGold>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventorySlot = GetComponent<InventorySlot>();
            if (inventorySlot.amountInSlot >= 1 && shopWindow.activeInHierarchy)
            {
                inventorySlot.amountInSlot -= 1;
                inventorySlot.updateAmountInSlot();

                int itemGoldValue = gameObject.GetComponent<BlockInfo>().block.goldValue;
                currentGold.currentGold += itemGoldValue;
                currentGold.updateGoldAmount();
            }
        }
        
    }
}
