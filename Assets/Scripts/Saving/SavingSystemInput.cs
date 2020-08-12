using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystemInput : MonoBehaviour
{
    [SerializeField] GameObject proceduralGenerationGO;
    [SerializeField] GameObject savedObjects;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject inventoryContainer;

    GameSession gameSession;
    CurrentGold currentGold;

    int gameSessionCurrentDay;
    int coinContainerCurrentGold;

    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        currentGold = FindObjectOfType<CurrentGold>();
        if (gameSession.isLoadedGame)
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        ES3.Save("proceduralGenerationGO", proceduralGenerationGO);
        ES3.Save("savedObjects", savedObjects);
        ES3.Save("inventory", inventory);
        gameSessionCurrentDay = gameSession.currentDay;
        ES3.Save("gameSessionCurrentDay", gameSessionCurrentDay);
        coinContainerCurrentGold = currentGold.currentGold;
        ES3.Save("coinContainerCurrentGold", coinContainerCurrentGold);
        print("Game Saved");
    }


    public void LoadGame()
    {
        proceduralGenerationGO = ES3.Load("proceduralGenerationGO", proceduralGenerationGO);
        savedObjects = ES3.Load("savedObjects", savedObjects);
        inventory = ES3.Load("inventory", inventory);
        gameSessionCurrentDay = ES3.Load("gameSessionCurrentDay", gameSessionCurrentDay);
        gameSession.currentDay = gameSessionCurrentDay;
        coinContainerCurrentGold = ES3.Load("coinContainerCurrentGold", coinContainerCurrentGold);
        currentGold.currentGold = coinContainerCurrentGold;
        UpdateSlotsManual();
        DestroyEnemiesNestedInChunks();
        print("Game Loaded");
    }

    private void DestroyEnemiesNestedInChunks()
    {
        // Destroys enemies nested inside chunks
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

    //TODO not sure why by equipped item slots aren't deleting their current item.  ES3 bug maybe?
    private void UpdateSlotsManual()
    {
        Transform equippedSlots = inventory.transform.GetChild(0);
        foreach (Transform slot in equippedSlots)
        {
            if (slot.childCount > 1)
            {
                Destroy(slot.GetChild(0).gameObject);
                RectTransform thisRect = slot.GetChild(1).gameObject.GetComponent<RectTransform>();
                thisRect.anchoredPosition = new Vector2(0, 0);
            }
        }
        foreach (Transform slot in inventoryContainer.transform)
        {
            slot.GetComponent<InventorySlot>().updateAmountInSlot();
        }
    }

    //TODO not working
    public void DeleteGame()
    {
        //ES3.DeleteFile("C:/Users/user/AppData/LocalLow/DefaultCompany/MiningSim2D/SaveFile.es3");
        print("Game Deleted");
    }
}
