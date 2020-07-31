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
            pickedUp = true;

            if (gameObject.GetComponent<Dirt>())
            {
                GameObject thisSlot = null;

                foreach (Transform child in inventoryContainer.transform)
                {
                    if (child.gameObject.GetComponent<Dirt>())
                    {
                        thisSlot = child.gameObject;
                        break;
                    }
                    else
                    {
                        continue;
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
                inventoryContainer.addClassToSlot("dirt", thisSlot);
            }

            Destroy(gameObject);
        }
    }
}
