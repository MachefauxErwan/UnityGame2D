using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;
    public List<Item> content = new List<Item>();
    private int contentCurentIndex = 0;
    public Image itemImageUI;
    public Sprite emptySpriteUI;
    public Text itemTextUI;

    public PlayerEffects playerEffects;
    private void Start()
    {
        UpdateInventoryUI();
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scene");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateUI();
    }
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateUI();
    }
    public void UpdateUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    public void ConsumeItem()
    {
        if(content.Count ==0)
        {
            return;
        }

        Item currentItem = content[contentCurentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurentIndex].image;
            itemTextUI.text = content[contentCurentIndex].Name;
        }
        else
        {
            itemImageUI.sprite = emptySpriteUI;
            itemTextUI.text = "";
        }
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurentIndex++;
        if(contentCurentIndex> content.Count-1)
        {
            contentCurentIndex = 0;
        }
        UpdateInventoryUI();
    }
    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurentIndex++;
        if (contentCurentIndex < 0 )
        {
            contentCurentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }
}
