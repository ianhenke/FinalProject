using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float viewRadius;
    [SerializeField] bool activated = false;

    EnemyMovement movement;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, playerTransform.position) < viewRadius)
        {
            FollowPlayer();
        }
        else if (activated)
        {
            Patrol();
        }
        else
        {
            Idle();
        }
    }

    public void FollowPlayer()
    {
        activated = true;
        movement.MoveToward(playerTransform.position);
    }

    Vector3 patrolPosition = Vector3.zero;

    public void Patrol()
    {
        if(Vector3.Distance(transform.position, patrolPosition) < 1)
        {
            patrolPosition = transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
        }

        movement.MoveToward(patrolPosition);
    }

    public void Idle()
    {
        movement.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(25);
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
}
