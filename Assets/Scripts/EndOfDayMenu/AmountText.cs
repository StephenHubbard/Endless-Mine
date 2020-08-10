using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmountText : MonoBehaviour
{
    public int amountInSlot = 0;

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = amountInSlot.ToString();
    }
}
