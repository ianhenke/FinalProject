using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void respawn()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
