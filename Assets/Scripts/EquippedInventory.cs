using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedInventory : MonoBehaviour
{
    public GameObject equippedItem;

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
    }

    

    private void Update()
    {
        detectActiveSlot();
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
