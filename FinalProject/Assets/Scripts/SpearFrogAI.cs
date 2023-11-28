using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFrogAI : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float viewRadius = 10f;
    [SerializeField] SpearThrower thrower;
    [SerializeField] float throwDelay = .2f;
    [SerializeField] AnimationStateChanger animationStateChanger;

    private bool canThrow = true;

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < viewRadius && canThrow)
        {
            canThrow = false;
            StartCoroutine(ThrowSpear());
            StartCoroutine(ChangeAnimationAfterDelay("Throwing", throwDelay));
        }
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
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
        thrower.Throw(playerTransform.position);
        yield return new WaitForSeconds(throwDelay);
        canThrow = true;
    }

    private IEnumerator ChangeAnimationAfterDelay(string animationName, float delay)
    {
        animationStateChanger.ChangeAnimationState(animationName);
        animationStateChanger.canChangeAnimation = false;
        yield return new WaitForSeconds(delay); // Wait for the specified duration
        animationStateChanger.canChangeAnimation = true;
    }
}
