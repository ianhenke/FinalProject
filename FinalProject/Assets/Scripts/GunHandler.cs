using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunHandler : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] GameObject tatesGun;
    [SerializeField] int maxAmmo = 16;
    [SerializeField] AudioSource shootAudio;

    private bool hasGun = false;

    private void Update()
    {
        if (ItemPickups.hasGun)
        {
            hasGun = true;
            tatesGun.SetActive(true);
            InventoryController.Instance.AddGunToInventory();
            
            InventoryController.Instance.UpdateGunAmmoText(maxAmmo);
        }
        else
        {
            ItemPickups.hasGun = false;
            hasGun = false;
            tatesGun.SetActive(false);
            InventoryController.Instance.RemoveGunFromInventory();            
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && hasGun && maxAmmo > 0)
        {
            Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            maxAmmo -= 1;
            
            InventoryController.Instance.UpdateGunAmmoText(maxAmmo);
        }
        else if(!(maxAmmo > 0) && hasGun)
        {
            ItemPickups.hasGun = false;
            hasGun = false;
            tatesGun.SetActive(false);
            InventoryController.Instance.RemoveGunFromInventory();
        }
    }

    private void Shoot(Vector3 targetPosition)
    {
        shootAudio.Play();

        GameObject newProjectile = Instantiate(projectilePrefab, tatesGun.transform.position, Quaternion.identity);

        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x);

        float degrees = Mathf.Rad2Deg * angle;

        newProjectile.transform.rotation = Quaternion.Euler(0, 0, degrees);

        Rigidbody2D newProjectileRB = newProjectile.GetComponent<Rigidbody2D>();

        newProjectileRB.velocity = direction * bulletSpeed;
        newProjectileRB.rotation = degrees;
    }
}
