using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
   
    private bool isInvinsible = false;
    public float InvisibleFlashDelay = 0.2f;
    public float InvisibleTimeAfterHit = 3f;
    public SpriteRenderer graphics;

    public AudioClip Hitsound;

    public static PlayerHealth instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealfManager dans la scene");
            return;
        }
        instance = this;
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDomage(20);
        }
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth+ amount)>maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

            healthBar.SetHealth(currentHealth);
    }

    public void TakeDomage(int domage)
    {
        if (!isInvinsible)
        {
            currentHealth -= domage;
            healthBar.SetHealth(currentHealth);
            AudioManager.instance.PlayClipAtPoint(Hitsound, transform.position);
            if(currentHealth <=0)
            {
                Die();
                return;
            }

            isInvinsible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        Debug.Log("player Dead");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }
    public void Respawn()
    {
        
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    public void Win()
    {
        Debug.Log("player Win");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        //GameOverManager.instance.OnPlayerWin();
    }
    public IEnumerator InvincibilityFlash()
    {
        while (isInvinsible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvisibleFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvisibleFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvisibleTimeAfterHit);
        isInvinsible = false;
    }
}
