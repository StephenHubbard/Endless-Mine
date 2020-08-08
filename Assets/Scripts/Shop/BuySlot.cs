using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    CurrentGold currentGold;
    EquippedInventory equippedInventory;

    private void Awake()
    {
        currentGold = FindObjectOfType<CurrentGold>();
        equippedInventory = FindObjectOfType<EquippedInventory>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            int itemCost = 0;
            
            GameObject itemInSlot = transform.GetChild(0).gameObject;
            
            if (itemInSlot.GetComponent<PickaxeInfo>())
            {
                itemCost = itemInSlot.GetComponent<PickaxeInfo>().pickaxe.goldValue;
            }
            else if (itemInSlot.GetComponent<WeaponInfo>())
            {
                itemCost = itemInSlot.GetComponent<WeaponInfo>().weapon.goldValue;
            }

            if (currentGold.currentGold >= itemCost)
            {
                currentGold.currentGold -= itemCost;
                ExchangeNewItem(itemInSlot);
            }
            else
            {
                print("not enough gold");
            }
        }
    }

    private void ExchangeNewItem(GameObject boughtItem)
    {
        foreach (GameObject slot in equippedInventory.slots)
        {
            if (boughtItem.GetComponent<PickaxeInfo>())
            {
                if (slot.transform.childCount > 0)
                {
                    if (slot.transform.GetChild(0).GetComponent<PickaxeInfo>())
                    {
                        Destroy(slot.transform.GetChild(0).gameObject);
                        boughtItem.transform.SetParent(slot.transform);
                        boughtItem.transform.position = slot.transform.position;
                    }
                }
            }
            else if (boughtItem.GetComponent<WeaponInfo>())
            {
                if (slot.transform.childCount > 0)
                {
                    if (slot.transform.GetChild(0).GetComponent<WeaponInfo>())
                    {
                        Destroy(slot.transform.GetChild(0).gameObject);
                        boughtItem.transform.SetParent(slot.transform);
                        boughtItem.transform.position = slot.transform.position;
                    }
                }
            }
            else if (boughtItem.GetComponent<TorchInfo>())
            {
                if (slot.transform.childCount > 0)
                {
                    if (slot.transform.GetChild(0).GetComponent<TorchInfo>())
                    {
                        Destroy(slot.transform.GetChild(0).gameObject);
                        boughtItem.transform.SetParent(slot.transform);
                        boughtItem.transform.position = slot.transform.position;
                    }
                }
            }
        }
        equippedInventory.UpdateActiveItemForce();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
