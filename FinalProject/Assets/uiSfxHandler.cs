using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class uiSfxHandler : MonoBehaviour
{
    [SerializeField] AudioSource buttonPressedSound;

    public void playButtonPressedSound()
    {
        buttonPressedSound.Play();
    }
}
