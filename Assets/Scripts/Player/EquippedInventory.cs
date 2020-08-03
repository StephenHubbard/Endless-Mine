using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedInventory : MonoBehaviour
{
    public GameObject equippedItem;
    public GameObject inventoryContainer;

    public GameObject[] slots;
    public bool[] activeSlots;
    public Sprite[] sprites;

    private void Awake()
    {
        activeSlots = new bool[5];
    }

    private void Start()
    {
        disableSlots();
        DefaultStartingSlot();
    }

    private void DefaultStartingSlot()
    {
        slots[0].GetComponent<Outline>().enabled = true;
        activeSlots[0] = true;
        equippedItem.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    private void Update()
    {
        detectActiveSlot();
        ToggleInventory();
    }

    private void ToggleInventory()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            CanvasGroup canvasGroup = inventoryContainer.GetComponent<CanvasGroup>();
            if (canvasGroup.alpha == 0)
            {
                canvasGroup.alpha = 1;
            }
            else
            {
                canvasGroup.alpha = 0;
            }
        }

    }

    private void disableSlots()
    {
        for (int i = 0; i < activeSlots.Length; i++)
        {
            activeSlots[i] = false;
        }
    }

    private void detectActiveSlot()
    {
        if (Input.GetButtonDown("1"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[0].GetComponent<Outline>().enabled = true;

            for (int i = 0; i < activeSlots.Length; i++)
            {
                activeSlots[i] = false;
            }
            activeSlots[0] = true;
            equippedItem.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }

        if (Input.GetButtonDown("2"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[1].GetComponent<Outline>().enabled = true;

            for (int i = 0; i < activeSlots.Length; i++)
            {
                activeSlots[i] = false;
            }
            activeSlots[1] = true;
            equippedItem.GetComponent<SpriteRenderer>().sprite = sprites[1];


        }

        if (Input.GetButtonDown("3"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[2].GetComponent<Outline>().enabled = true;

            for (int i = 0; i < activeSlots.Length; i++)
            {
                activeSlots[i] = false;
            }
            activeSlots[2] = true;
            equippedItem.GetComponent<SpriteRenderer>().sprite = sprites[2];

        }

        if (Input.GetButtonDown("4"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[3].GetComponent<Outline>().enabled = true;

            for (int i = 0; i < activeSlots.Length; i++)
            {
                activeSlots[i] = false;
            }
            activeSlots[3] = true;
            equippedItem.GetComponent<SpriteRenderer>().sprite = sprites[3];

        }

        if (Input.GetButtonDown("5"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[4].GetComponent<Outline>().enabled = true;

            for (int i = 0; i < activeSlots.Length; i++)
            {
                activeSlots[i] = false;
            }
            activeSlots[4] = true;
        }
    }
}
