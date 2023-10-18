using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SlideFade : MonoBehaviour
{
    [SerializeField] Transform outTransform;
    [SerializeField] Transform inTransform;
    [SerializeField] float slideTime = 5;

    private void Start()
    {
        SlideOut();
    }

    public void SlideIn(string sceneName)
    {
        StartCoroutine(SlideInRoutine(sceneName));
    }

    public void SlideOut()
    {
        StartCoroutine(SlideOutRoutine());
    }

    IEnumerator SlideInRoutine(string sceneName)
    {
        float timer = 0;

        while (timer < slideTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(outTransform.position, inTransform.position, timer / slideTime);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator SlideOutRoutine()
    {
        float timer = 0;

        while(timer < slideTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(inTransform.position, outTransform.position, timer / slideTime);
            yield return null;
        }
    }
}
