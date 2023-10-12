using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    private Health health;
    private bool canBeHit = true;

    private void Start()
    {
        health = GetComponent<Health>();
    }
    private void OnParticleCollision(GameObject particle)
    {
        if (particle.CompareTag("Bomb"))
        {
            health.TakeDamage(1);
        }
        if (particle.CompareTag("IndianaJonesBoulder") && canBeHit)
        {
            health.TakeDamage(50);
            canBeHit = false;
            StartCoroutine(ResetDamageCooldown(1.0f));
        }
    }

    IEnumerator ResetDamageCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        canBeHit = true;
    }
}
