using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenHandler : MonoBehaviour
{
    public void RestartLevelButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenuButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
