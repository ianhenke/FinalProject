using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    [SerializeField] AudioSource healthPickupSound;
    public int healthAmount = 25; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            collision.gameObject.GetComponent<Health>().AddHealth(healthAmount);
            healthPickupSound.Play();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
