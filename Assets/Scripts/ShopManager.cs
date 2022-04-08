using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Text pnjNameText;
    public Animator animator;

    public GameObject SellButtonPrefab;
    public Transform SellButtonsParent;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scene");
            return;
        }
        instance = this;

       
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemsToSell( items);
        animator.SetBool("isOpen", true);
    }

     void UpdateItemsToSell(Item[] items)
    {
        for (int i = 0; i < SellButtonsParent.childCount; i++)
        {
            Destroy(SellButtonsParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(SellButtonPrefab, SellButtonsParent);
            SellButtonItem buttonScrip = button.GetComponent<SellButtonItem>();
            buttonScrip.itemName.text = items[i].Name;
            buttonScrip.itemImage.sprite = items[i].image;
            buttonScrip.itemPrice.text = items[i].price.ToString();

            buttonScrip.item = items[i];

            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScrip.BuyItem(); });
        }
    }
    public void CloseChop()
    {
        animator.SetBool("isOpen", false);
        
    }
}
