using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit(); //will not work in editor
    }

    public void SettingsButton()
    {
        SettingsMenuHandler.lastScene = "MainMenu";
        SceneManager.LoadScene("Settings");
    }
}
