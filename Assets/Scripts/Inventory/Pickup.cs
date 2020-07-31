using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    InventoryContainer inventoryContainer;
    private bool pickedUp = false;

    private void Awake()
    {
        inventoryContainer = FindObjectOfType<InventoryContainer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player" && pickedUp == false)
        {
            BlockInfo blockInfo = gameObject.GetComponent<BlockInfo>();
            pickedUp = true;

            if (blockInfo)
            {
                addToInventory(blockInfo);
            }

            

            Destroy(gameObject);
        }
    }

    private void addToInventory(BlockInfo blockInfo)
    {
        GameObject thisSlot = null;

        foreach (Transform child in inventoryContainer.transform)
        {
            if (child.gameObject.GetComponent<BlockInfo>() != null)
            {
                if (child.gameObject.GetComponent<BlockInfo>().block == blockInfo.block)
                {
                    thisSlot = child.gameObject;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        if (thisSlot == null)
        {
            foreach (Transform child in inventoryContainer.transform)
            {
                if (child.gameObject.GetComponent<InventorySlot>().isOccupied == false)
                {
                    thisSlot = child.gameObject;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        inventoryContainer.addClassToSlot(blockInfo, thisSlot);
    }
}
