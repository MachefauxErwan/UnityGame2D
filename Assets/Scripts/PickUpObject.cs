using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public Item item;
    public AudioClip soundToplay;

    private Text InteractUI;
    private string infoTexte = "PRESS    E    TO    INTERACT";
    private bool is_in_range;
    void Awake()
    {
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_in_range)
        {
            TakeItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.text = infoTexte;
            InteractUI.enabled = true;
            is_in_range = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractUI.enabled = false;
            is_in_range = false;
        }
    }

    private void TakeItem()
    {

        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();

        AudioManager.instance.PlayClipAtPoint(soundToplay, transform.position);
        InteractUI.enabled = false;
        Destroy(gameObject);
    }
}
