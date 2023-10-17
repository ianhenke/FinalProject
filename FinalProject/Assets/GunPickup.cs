using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            ItemPickups.hasGun = true;
            gameObject.SetActive(false);
        }
    }
}
