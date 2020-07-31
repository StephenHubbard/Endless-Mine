using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContainer : MonoBehaviour
{
    public Sprite dirtSprite;

    public void addClassToSlot(string thisString, GameObject thisSlot)
    {
        if (thisString == "dirt")
        {
            if (thisSlot != null)
            {
                if (!this.GetComponent<Dirt>())
                {
                    thisSlot.AddComponent<Dirt>();
                }
                thisSlot.GetComponent<InventorySlot>().amountInSlot += 1;
                thisSlot.GetComponent<InventorySlot>().updateAmountInSlot();
                Image thisImage = thisSlot.transform.GetChild(0).gameObject.GetComponent<Image>();
                thisImage.sprite = dirtSprite;

            }
            else if (thisSlot = null)
            {

                // TODO only replace sprite if null
                thisSlot.AddComponent<Dirt>();
                Image thisImage = thisSlot.transform.GetChild(0).gameObject.GetComponent<Image>();
                thisImage.sprite = dirtSprite;
                thisSlot.GetComponent<InventorySlot>().amountInSlot += 1;
                thisSlot.GetComponent<InventorySlot>().updateAmountInSlot();
            }
        }
    }
}
