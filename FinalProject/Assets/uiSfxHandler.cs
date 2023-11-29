
using UnityEngine;

public class uiSfxHandler : MonoBehaviour
{
    [SerializeField] AudioSource buttonPressedSound;

    public void playButtonPressedSound()
    {
        buttonPressedSound.Play();
    }
}
