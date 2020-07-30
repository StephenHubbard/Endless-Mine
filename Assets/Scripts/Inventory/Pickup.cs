using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    BackpackInventory backpackInventory;
    private bool pickedUp = false;

    private void Awake()
    {
        backpackInventory = FindObjectOfType<BackpackInventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && pickedUp == false)
        {
            pickedUp = true;

            if (gameObject.GetComponent<Dirt>())
            {
                backpackInventory.amountOfDirt += 1;
                backpackInventory.updateAmountInSlot();
            }

            Destroy(gameObject);
        }
    }
}
