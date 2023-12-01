using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexController : MonoBehaviour
{
    [SerializeField] GameObject[] movementPoints;
    public float speed;

    private Rigidbody2D rb;
    private int currentPointIndex = 0;
    private Vector3 currentTarget;
    private bool movingForward = true;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        SetNextTarget();
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void SetNextTarget()
    {
        if (movementPoints.Length == 0)
            return;

        currentTarget = movementPoints[currentPointIndex].transform.position;
    }

    private void MoveTowardsTarget()
    {
        if (movementPoints.Length == 0)
            return;

        Vector2 direction = (currentTarget - transform.position).normalized;

        rb.velocity = direction * speed;

        if (direction.x > 0 && !movingForward || direction.x < 0 && movingForward)
        {
            flip();
        }

        if (Vector2.Distance(transform.position, currentTarget) < 1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= movementPoints.Length)
            {
                currentPointIndex = 0;
            }
            SetNextTarget();
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
