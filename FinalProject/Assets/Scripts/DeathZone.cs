using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Tate"))
        {
            other.gameObject.GetComponent<Respawn>().respawn();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
