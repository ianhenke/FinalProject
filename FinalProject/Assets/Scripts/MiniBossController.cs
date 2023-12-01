using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] AnimationStateChanger animationStateChanger;

    [SerializeField] EnemyHealth health;

    EnemyMovement movement;


    [SerializeField] ComplexController patrolController;
    [SerializeField] LaserShootingAI laserShootingAI;

    Rigidbody2D rb;
    PolygonCollider2D polygonCollider;

    public static Action bossHasDied;

    [SerializeField] AudioSource deathSound;
    [SerializeField] HealthController healthController;

    private bool soundHasPlayed = false;


    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        rb = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        patrolController.enabled = false;
        laserShootingAI.enabled = false;
        healthController.gameObject.SetActive(false);
        animationStateChanger.ChangeAnimationState("Running");
    }

    private void Update()
    {
        if(!healthController.gameObject.activeSelf)
        {
            healthController.gameObject.SetActive(true);
        }

        healthController.SetHealth(health.getHealth()/10);

        if(health.getHealth() > health.maxHealth * .5f)
        {
            FollowPlayer();
        }
        else if(health.getHealth() > health.maxHealth * 0)
        {
            movement.enabled = false;

            rb.gravityScale = 0;
            patrolController.enabled = true;
            laserShootingAI.enabled = true;
            animationStateChanger.ChangeAnimationState("Flying");
        }
        else if(health.getHealth() <= 0)
        {
            patrolController.enabled = false;
            laserShootingAI.enabled = false;
            rb.velocity = Vector3.zero;
            polygonCollider.enabled = false;
            animationStateChanger.ChangeAnimationState("Exploding");
            StartCoroutine(Destroy());
        }
    }

    public void FollowPlayer()
    {
        movement.MoveToward(playerTransform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tate"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(25);
        }
    }
    private IEnumerator Destroy() 
    {
        if (!soundHasPlayed)
        {
            deathSound.Play();
            soundHasPlayed = true;
        }
        yield return new WaitForSeconds(7f);
        bossHasDied?.Invoke();
        healthController.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
