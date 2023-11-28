using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] HealthController healthController;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if(currentHealth - damageAmount > 0)
        {
            currentHealth -= damageAmount;
        }
        else
        {
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
            SceneManager.LoadScene("DeathScreen");
            
        }

        healthController.SetHealthText(currentHealth);
    }

    public void AddHealth(int addAmount)
    {
        if(currentHealth + addAmount < maxHealth) 
        { 
        currentHealth += addAmount;
        }
        else if(currentHealth + addAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthController.SetHealthText(currentHealth);
    }
}
