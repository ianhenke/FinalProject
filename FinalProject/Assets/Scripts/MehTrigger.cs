using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MehTrigger : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float viewRadius;

    [SerializeField] GameObject meh;

    private void Awake()
    {
        meh.SetActive(false);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < viewRadius)
        {
            meh.SetActive(true);
        }
    }
}
