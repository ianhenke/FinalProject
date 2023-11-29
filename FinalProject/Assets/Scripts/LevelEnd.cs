using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] string nextLevel;
    [SerializeField] GameObject cover1;
    [SerializeField] GameObject cover2;
    [SerializeField] GameObject cover3;
    [SerializeField] GameObject cover4;
    [SerializeField] GameObject cameraReference;
    [SerializeField] GameObject invisibleBoundry;
    [SerializeField] GameObject invisibleBoundry2;
    [SerializeField] AudioSource portalActivateSound;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tate"))
        {
            invisibleBoundry.SetActive(true);
            invisibleBoundry2.SetActive(true);
            portalActivateSound.Play();
            Debug.Log("Level Complete");
            cameraReference.GetComponent<CameraZoomController>().ZoomIn();

            cover1.GetComponent<SlideFade>().SlideIn(nextLevel);
            cover2.GetComponent<SlideFade>().SlideIn(nextLevel);
            cover3.GetComponent<SlideFade>().SlideIn(nextLevel);
            cover4.GetComponent<SlideFade>().SlideIn(nextLevel);

            ItemPickups.ClearAllItems();
        }
    }
}
