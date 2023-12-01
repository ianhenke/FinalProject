using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;

    private void Awake()
    {
        triggerObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tate"))
        {
            triggerObject.SetActive(true);
        }
    }
}
