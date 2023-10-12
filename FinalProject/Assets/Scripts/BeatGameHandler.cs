using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatGameHandler : MonoBehaviour
{
    public void MainMenuButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
