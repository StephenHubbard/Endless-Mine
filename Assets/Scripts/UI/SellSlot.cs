﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // IPointerClickHandler

    InventorySlot inventorySlot;
    CurrentGold currentGold;
    public GameObject shopWindow;

    private bool rightMouseButtonHeldDown = false;

    private int itemGoldValue;

    private void Awake()
    {
        currentGold = FindObjectOfType<CurrentGold>();
    }

    private void Update()
    {
        if (rightMouseButtonHeldDown)
        {
            sellItem();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventorySlot = GetComponent<InventorySlot>();
            int itemGoldValue = gameObject.GetComponent<BlockInfo>().block.goldValue;

            rightMouseButtonHeldDown = true;
            StartCoroutine(sellItem());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightMouseButtonHeldDown = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator sellItem()
    {

        // TODO can technically sell with shop window open and inventory "closed" because of hidden alpha
        if (inventorySlot.amountInSlot >= 1 && shopWindow.activeInHierarchy)
        {
            inventorySlot.amountInSlot -= 1;
            inventorySlot.updateAmountInSlot();

            itemGoldValue = gameObject.GetComponent<BlockInfo>().block.goldValue;
            currentGold.currentGold += itemGoldValue;
            currentGold.updateGoldAmount();
            yield return new WaitForSeconds(.1f);
            StartCoroutine(sellItem());
        }

        yield return null;
    }
}
