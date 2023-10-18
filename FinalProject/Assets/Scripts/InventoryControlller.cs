using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private static InventoryController instance;

    [SerializeField] private Image gunImage;
    [SerializeField] Text gunAmmoCount;

    public static InventoryController Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("InventoryController is not initialized.");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddGunToInventory()
    {
        if (gunImage != null)
        {
            gunImage.enabled = true;
        }
    }

    public void RemoveGunFromInventory()
    {
        if (gunImage != null)
        {
            gunImage.enabled = false;
        }
    }

    public void UpdateGunAmmoText(int ammoCount)
    {
        gunAmmoCount.text = ammoCount.ToString();
    }
}

