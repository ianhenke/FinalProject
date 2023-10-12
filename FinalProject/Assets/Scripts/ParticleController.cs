using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem system; // Reference to your Particle System.

    private void Start()
    {
        system = GetComponent<ParticleSystem>();
        StartCoroutine(ParticleControlRoutine());
    }

    private IEnumerator ParticleControlRoutine()
    {
        while (true)
        {
            system.Play();

            yield return new WaitForSeconds(1.5f);

            system.Stop();

            yield return new WaitForSeconds(1.5f);
        }
    }
}
