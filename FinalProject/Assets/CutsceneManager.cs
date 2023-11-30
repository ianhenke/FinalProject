using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

   void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0 )
        {
            SceneManager.LoadScene(sceneName);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
