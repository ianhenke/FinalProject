using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform startingPoint;
    [SerializeField] Transform endingPoint;

    [SerializeField] GameObject doorBlock;

    public static event Action tateEntersElevator;

    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    private bool playerOnPlatform;

    private bool cutScenePlayed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startingPoint.position;
        doorBlock.SetActive(false);
        playerOnPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            Vector2 moveDirection = (endingPoint.position - transform.position).normalized;

            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, endingPoint.position) < 0.1f)
            {
                rb.velocity = Vector2.zero;
                rb.MovePosition(endingPoint.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tate") && !cutScenePlayed)
        {
            playerOnPlatform = true;
            doorBlock.SetActive(true);
            tateEntersElevator?.Invoke();
            cutScenePlayed = true;
        }
    }
}
