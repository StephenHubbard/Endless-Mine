using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedInventory : MonoBehaviour
{
    public GameObject[] slots;

    private void Update()
    {
        detectActiveSlot();
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
        }

        if (Input.GetButtonDown("2"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[1].GetComponent<Outline>().enabled = true;
        }

        if (Input.GetButtonDown("3"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[2].GetComponent<Outline>().enabled = true;
        }

        if (Input.GetButtonDown("4"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[3].GetComponent<Outline>().enabled = true;
        }

        if (Input.GetButtonDown("5"))
        {
            foreach (GameObject slot in slots)
            {
                slot.GetComponent<Outline>().enabled = false;
            }
            slots[4].GetComponent<Outline>().enabled = true;
        }
    }
}
