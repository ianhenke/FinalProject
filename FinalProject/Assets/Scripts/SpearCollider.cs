using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(15);
            gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
