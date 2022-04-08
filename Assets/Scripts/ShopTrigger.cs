using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public bool isInRange;
    public string pnjName;

    public Item[] itemToSell;

    private Text InteractUI;

    private string infoTexte = "PRESS    E   TO    INTERACT";

    void Awake()
    {
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemToSell, pnjName);
        }
        if (!DialogManager.instance.GetDialogIsOpen())
        {
            infoTexte = "PRESS    E   TO    INTERACT";
            InteractUI.text = infoTexte;
        }
        else
        {
            infoTexte = "PRESS    ENTER   TO    INTERACT";
            InteractUI.text = infoTexte;
        }

    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            InteractUI.text = infoTexte;
            InteractUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            InteractUI.enabled = false;
            isInRange = false;
            ShopManager.instance.CloseChop();
        }
    }
}
