using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAudioManager : MonoBehaviour
{
    [SerializeField] ParticleSystem parentParticleSystem;
    [SerializeField] AudioSource audioSource;

    private int currentNumberOfParticles = 0;

    private void Start()
    {
        parentParticleSystem = this.GetComponent<ParticleSystem>();

        if(parentParticleSystem == null)
        {
            Debug.Log("Parent Particle System is Null!");
        }
    }

    private void Update()
    {
        if(parentParticleSystem.particleCount > currentNumberOfParticles)
        {
            Debug.Log("PLAYING EXPLOSION");
            audioSource.Play();
        }

        currentNumberOfParticles = parentParticleSystem.particleCount;
    }
}
