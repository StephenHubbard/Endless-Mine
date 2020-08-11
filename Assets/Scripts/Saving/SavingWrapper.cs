using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingWrapper : MonoBehaviour
{
    const string defaultSaveFile = "save";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }
}
