using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossTriggger : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
    [SerializeField] GameObject triggerObject2;
    [SerializeField] GameObject miniBossArena;

    BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        triggerObject.SetActive(false);
        triggerObject2.SetActive(false);
        miniBossArena.SetActive(false);
        MiniBossController.bossHasDied += RemoveBarriers;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tate"))
        {
            triggerObject.SetActive(true);
            triggerObject2.SetActive(true);
            miniBossArena.SetActive(true);
        }
    }

    private void RemoveBarriers()
    {
        triggerObject.SetActive(false);
        triggerObject2.SetActive(false);
        boxCollider.enabled = false;
    }
}
