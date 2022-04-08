using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scene");
            return;
        }
        instance = this;
    }


    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateUI();

        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);

       // string[] itemSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');
        var itemSaved = PlayerPrefs.GetString("inventoryItems", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < itemSaved.Length; i++)
        {
            int id = int.Parse(itemSaved[i]);
            Item currentItem = ItemsDataBase.instance.AllItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
        }

        Inventory.instance.UpdateInventoryUI();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        if(CurrentSceneManager.instance.LevelToUnLock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.LevelToUnLock);
        }

        //Sauvegarde
        string itemInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemInInventory);
    }
}
