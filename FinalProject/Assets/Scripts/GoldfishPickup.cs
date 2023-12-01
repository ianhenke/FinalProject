using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldfishPickup : MonoBehaviour
{
    [SerializeField] GameObject levelEnd;
    [SerializeField] AudioSource pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            levelEnd.SetActive(true);
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        pickupSound.Play();
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
    }
}
