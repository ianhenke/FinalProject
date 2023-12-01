using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string currentState = "Idle";

    public bool canChangeAnimation = true;

    public void ChangeAnimationState(string newAnimationState)
    {
        if(newAnimationState == currentState || canChangeAnimation == false)
        {
            return;
        }
        
        Debug.Log("changing animation to:" + newAnimationState);

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }
}
