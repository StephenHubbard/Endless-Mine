using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystemInput : MonoBehaviour
{
    [SerializeField] GameObject proceduralGenerationGO;
    [SerializeField] GameObject savedObjects;
    [SerializeField] Block dirt;

    public void SaveGame()
    {
        ES3.Save("proceduralGenerationGO", proceduralGenerationGO);
        ES3.Save("savedObjects", savedObjects);
        print("Game Saved");
    }

    public void LoadGame()
    {
        proceduralGenerationGO = ES3.Load("proceduralGenerationGO", proceduralGenerationGO);
        savedObjects = ES3.Load("savedObjects", savedObjects);
        print("Game Loaded");

        foreach (Transform child in proceduralGenerationGO.transform)
        {
            foreach (Transform thisChild in child)
            {
                if (!thisChild.gameObject.GetComponent<SaveableEntity>())
                {
                    Destroy(thisChild.gameObject);
                }
                thisChild.gameObject.SetActive(true);
            }
        }
    }

    public void DeleteGame()
    {
        //ES3.DeleteFile("C:/Users/user/AppData/LocalLow/DefaultCompany/MiningSim2D/SaveFile.es3");
        print("Game Deleted (not working)");
    }
}
