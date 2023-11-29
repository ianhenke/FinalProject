using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenManager : MonoBehaviour
{
    [SerializeField] Toggle fullScreenToggle;

    private bool isFullScreen = false;

    private void OnEnable()
    {
        if(Screen.fullScreen)
        {
            isFullScreen = true;
        }
        else
        {
            isFullScreen = false;
        }

        fullScreenToggle.SetIsOnWithoutNotify(isFullScreen);
        Debug.Log("BOOL: " + isFullScreen);
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        isFullScreen = !isFullScreen;
        Debug.Log("ON VALUE CHANGED CALLED BOOL: " + isFullScreen);
    }
}
