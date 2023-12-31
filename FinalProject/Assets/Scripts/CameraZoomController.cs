using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField] float zoomDuration = 3.0f;      // Duration of the zoom effect.
    [SerializeField] float targetSize = 20;  // The desired orthographic size when zoomed out.

    private Camera mainCamera;
    private float orignalSize;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        orignalSize = mainCamera.orthographicSize;

        // Start the zoom out coroutine.
        StartCoroutine(ZoomOut());
    }

    public void ZoomIn()
    {
        StartCoroutine(ZoomInRoutine());
    }

    private IEnumerator ZoomOut()
    {
        float timer = 0;
        while (timer < zoomDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(orignalSize, targetSize, timer / zoomDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        mainCamera.orthographicSize = targetSize;
    }
    private IEnumerator ZoomInRoutine()
    {
        float timer = 0;
        zoomDuration = .5f;
        while (timer < zoomDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(targetSize, orignalSize, timer / zoomDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        mainCamera.orthographicSize = orignalSize;
    }

}
