using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedInventory : MonoBehaviour
{
    public GameObject equippedItemSprite = null;
    public GameObject inventoryContainer;

    public GameObject[] slots;
    public bool[] activeSlots;
    public Sprite[] sprites;

    public GameObject activeItem = null;

    private void Awake()
    {
        activeSlots = new bool[5];
        activeItem = slots[0].transform.GetChild(0).gameObject;
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
        equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[0].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
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
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
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
            equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[0].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            activeItem = slots[0].transform.GetChild(0).gameObject;
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
            equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            activeItem = slots[1].transform.GetChild(0).gameObject;
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
            equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[2].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            activeItem = slots[2].transform.GetChild(0).gameObject;

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
            equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[3].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            activeItem = slots[3].transform.GetChild(0).gameObject;

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
            equippedItemSprite.GetComponent<SpriteRenderer>().sprite = slots[4].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            activeItem = slots[4].transform.GetChild(0).gameObject;

        }
    }
}
