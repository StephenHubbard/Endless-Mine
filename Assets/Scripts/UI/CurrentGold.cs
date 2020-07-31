﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentGold : MonoBehaviour
{

    public TextMeshProUGUI currentGoldText;
    public int currentGold = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateGoldAmount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGoldAmount()
    {
        currentGoldText.text = currentGold.ToString();
    }
}
