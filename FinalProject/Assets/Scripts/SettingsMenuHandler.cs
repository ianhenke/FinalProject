using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuHandler : MonoBehaviour
{
    public static string lastScene = "";

    public void BackButton()
    {
        Debug.Log("loaded: " + lastScene);
        SceneManager.LoadScene(lastScene);
    }
}
