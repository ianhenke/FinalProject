using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    public static bool hasGun = false;

    public static void ClearAllItems()
    {
        hasGun = false;
    }
}
