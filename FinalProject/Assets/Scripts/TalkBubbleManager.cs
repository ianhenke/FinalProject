using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkBubbleManager : MonoBehaviour
{
    [SerializeField] GameObject talkBubble;
    [SerializeField] TextMeshPro talkText;
    [SerializeField] float displayTime;

    private string[] phrases = {
        "Where in the world am I?",
        "Wohhhhh",
        "Oh jeez",
        "My name Jeff",
        "Smells nice"
    };

    private void Awake()
    {
        talkBubble.SetActive(false);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            StartCoroutine(DisplayTextRoutine());
        }
        else
        {
            talkBubble.SetActive(false);
        }
    }

    IEnumerator DisplayTextRoutine()
    {
        string randomPhrase = phrases[Random.Range(0, phrases.Length)];
        talkText.text = randomPhrase;
        talkBubble.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        talkBubble.SetActive(false);
    }
}
