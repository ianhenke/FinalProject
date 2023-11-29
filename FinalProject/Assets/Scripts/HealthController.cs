using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    Text healthText;
    [SerializeField] Image healthBarFill;

    private void Awake()
    {
        healthText = GetComponent<Text>();
    }

    public void SetHealth(int newHealth)
    {
        healthBarFill.fillAmount = newHealth / 100f;
        Debug.Log("NEW HEALTH: " + newHealth / 100f);
    }

}
