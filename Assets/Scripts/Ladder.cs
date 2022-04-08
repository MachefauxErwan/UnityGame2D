using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private bool is_in_range;
    private PlayerMovement player;
    public Tilemap Fondation;
    private Text InteractUI;
    
    private string infoTexte = "PRESS    \u2191    TO    INTERACT";

    void Awake()
    {       
        player = GameObject.FindObjectOfType<PlayerMovement>(); 
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (is_in_range && player.isClimbing == true && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            player.isClimbing = false;
            Fondation.GetComponent<TilemapCollider2D>().enabled = true;
            Debug.Log("descente");
            return;
        }
        if (is_in_range && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            player.isClimbing = true;
            Fondation.GetComponent<TilemapCollider2D>().enabled = false;
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
            player.isClimbing = false;
            Fondation.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
