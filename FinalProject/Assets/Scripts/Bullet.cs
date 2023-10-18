using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(25);
        }
        Destroy(gameObject);
    }
}
