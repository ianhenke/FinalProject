using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] GameObject tatesGun;
    private bool hasGun;

    private void Update()
    {
        if (ItemPickups.hasGun)
        {
            hasGun = true;
            tatesGun.SetActive(true);
        }
        else
        {
            hasGun = false;
            tatesGun.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && hasGun)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

    }


}
