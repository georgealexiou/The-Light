using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialDialogue
{
    public string tutorialType;

    [TextArea(3,10)]
    public string[] sentences;

}
