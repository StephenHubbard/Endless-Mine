using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    InventorySlot inventorySlot;
    private bool pickedUp = false;

    private void Awake()
    {
        inventorySlot = FindObjectOfType<InventorySlot>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && pickedUp == false)
        {
            pickedUp = true;

            if (gameObject.GetComponent<Dirt>())
            {
                inventorySlot.amountInSlot += 1;
                inventorySlot.updateAmountInSlot();
            }

            Destroy(gameObject);
        }
    }
}
