using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShootingAI : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float viewRadius = 10f;
    [SerializeField] SpearThrower thrower;
    [SerializeField] float throwDelay = .2f;
    [SerializeField] AudioSource throwAudio;

    private bool canThrow = true;

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < viewRadius && canThrow)
        {
            canThrow = false;
            StartCoroutine(ThrowSpear());
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (transform.position == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }

    IEnumerator ThrowSpear()
    {
        throwAudio.Play();
        thrower.Throw(playerTransform.position);
        yield return new WaitForSeconds(throwDelay);
        canThrow = true;
    }
}
