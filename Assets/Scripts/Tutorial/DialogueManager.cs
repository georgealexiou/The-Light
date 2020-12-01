using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(TutorialDialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.tutorialType);
    }
}
