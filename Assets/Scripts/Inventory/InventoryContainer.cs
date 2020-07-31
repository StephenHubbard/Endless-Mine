using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContainer : MonoBehaviour
{
    public Sprite dirtSprite;

    public void addClassToSlot(BlockInfo blockInfo, GameObject thisSlot)
    {
        thisSlot.GetComponent<InventorySlot>().isOccupied = true;
        thisSlot.GetComponent<InventorySlot>().isEmpty();

        if (!thisSlot.GetComponent<BlockInfo>())
        {
            thisSlot.AddComponent<BlockInfo>();
            thisSlot.GetComponent<BlockInfo>().block = blockInfo.block;
            Image thisImage = thisSlot.transform.GetChild(0).gameObject.GetComponent<Image>();
            thisImage.sprite = blockInfo.block.sprite;
        }
        thisSlot.GetComponent<InventorySlot>().amountInSlot += 1;
        thisSlot.GetComponent<InventorySlot>().updateAmountInSlot();
    }
}
