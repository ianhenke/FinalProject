using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    [SerializeField] AnimationStateChanger animationStateChanger;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToward(Vector3 target)
    {
        targetPosition = target;
    }

    public void Stop()
    {
        targetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        if (rb.velocity.magnitude == 0)
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }
        else
        {
            animationStateChanger.ChangeAnimationState("Running");
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
