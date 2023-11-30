using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenHandler : MonoBehaviour
{
    public void RestartLevelButton()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        string sceneName = "Level " + currentLevel;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenuButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
