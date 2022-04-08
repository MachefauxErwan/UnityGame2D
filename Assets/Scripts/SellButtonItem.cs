using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;
    public void BuyItem()
    {
        Inventory inventory =  Inventory.instance;

        if (inventory.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateUI();
        }
    }
}
