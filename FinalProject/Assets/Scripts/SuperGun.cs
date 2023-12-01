using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGun : MonoBehaviour
{
    public static Action activateSuperGun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activateSuperGun?.Invoke();
    }
}
