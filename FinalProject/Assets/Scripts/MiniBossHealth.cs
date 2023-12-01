using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] AudioSource takeDamageAudio;
    int currentHealth;
    [SerializeField] HealthController healthController;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        takeDamageAudio.Play();
        healthController.SetHealth(currentHealth / 10);
    }

    public int getHealth()
    {
        return currentHealth;
    }
}
