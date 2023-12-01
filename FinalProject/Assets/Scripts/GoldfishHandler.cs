using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldfishHandler : MonoBehaviour
{
    [SerializeField] GameObject goldfish;

    private void Awake()
    {
        EnemyHealth.kingFrogDied += GoldFishTime;
    }

    private void GoldFishTime()
    {
        Debug.Log("KING FROG HAS DIED!!!!!!!!!!!!!!!!!!");
        goldfish.SetActive(true);
    }
}
