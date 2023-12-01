using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject sideKick;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] GameObject tateTalkBubble;
    [SerializeField] TextMeshPro tateTalkText;

    private void Awake()
    {
        sideKick.SetActive(false);
        dialogueBox.SetActive(false);
    }

    void Start()
    {
        MovingPlatform.tateEntersElevator += BeginDialogue;
    }

    private void OnDisable()
    {
        MovingPlatform.tateEntersElevator -= BeginDialogue;
    }

    private void BeginDialogue()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        sideKick.SetActive(true);
        yield return new WaitForSeconds(.5f);
        
        dialogueText.text = "Hey. Rumor is King Frogs right hand man roams these parts. Watch Out";
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogueBox.SetActive(false);
       
        tateTalkText.text = "Thanks for the heads up boss";
        tateTalkBubble.SetActive(true);
        yield return new WaitForSeconds(2);
        tateTalkBubble.SetActive(false);

        dialogueText.text = "Go beast mode if you see him!";
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogueBox.SetActive(false);

        tateTalkText.text = "Will do!";
        tateTalkBubble.SetActive(true);
        yield return new WaitForSeconds(2);
        tateTalkBubble.SetActive(false);

        sideKick.SetActive(false);
    }
}
