using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    Text healthText;

    private void Awake()
    {
        healthText = GetComponent<Text>();
    }

    public void SetHealthText(int newHealth)
    {
        healthText.text = "Health: " + newHealth.ToString();
    }

}
