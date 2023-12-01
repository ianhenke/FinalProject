using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] AudioSource takeDamageAudio;
    int currentHealth;

    public bool IsMiniBoss = false;
    public bool IsKingFrog = false;

    public static Action kingFrogDied;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        takeDamageAudio.Play();

        if (currentHealth <= 0 && !IsMiniBoss)
        {
            Die();
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        if(IsKingFrog)
        {
            kingFrogDied?.Invoke();
        }

        Destroy(gameObject);
    }
}
