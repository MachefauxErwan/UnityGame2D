using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints = 10;

    public AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(PlayerHealth.instance.currentHealth!= PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAtPoint(pickupSound, transform.position);
                PlayerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
            
        }
    }
}
