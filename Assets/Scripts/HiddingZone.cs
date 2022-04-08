using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddingZone : MonoBehaviour
{
    public TilemapRenderer hiddingZone;
    public SpriteRenderer Details;

    private void Awake()
    {
        hiddingZone = GameObject.FindGameObjectWithTag("HiddingZone").GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hiddingZone.enabled = false;
            Details.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            hiddingZone.enabled = true;
            Details.enabled = true;
        }
    }
}
