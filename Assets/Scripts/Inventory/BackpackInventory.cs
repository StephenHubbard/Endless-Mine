using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackpackInventory : MonoBehaviour
{
    public TextMeshProUGUI amountInSlot1;
    public int amountOfDirt = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateAmountInSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAmountInSlot()
    {
        amountInSlot1.text = amountOfDirt.ToString();
    }
}
