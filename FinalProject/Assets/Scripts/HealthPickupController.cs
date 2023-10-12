using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            collision.gameObject.GetComponent<Health>().AddHealth(25);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
