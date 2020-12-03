using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    private PlayerMovement controls;
    public GameObject tutorialCanvas;
    private TMP_Text text;
    public string[] popuptext;
    public int level = 1;
    private int popupIndex = 0;

    public bool playerMoved = false;

    void Start()
    {
        controls = new PlayerMovement();

        Transform textTr = tutorialCanvas.transform.Find("Text (TMP)");
        text = textTr.GetComponent<TMP_Text>();
    }

    void Update()
    {

        for (int i = 0; i < popuptext.Length; i++)
        {
            if (i == popupIndex)
            {
                text.text = popuptext[popupIndex];
                tutorialCanvas.SetActive(true);
            }
        }


        switch (level)
        {
            case 1:
                if (popupIndex == 0)
                {

                    if (playerMoved)
                    {
                        popupIndex++;
                        tutorialCanvas.SetActive(false);
                    }
                }
                break;

            case 2:
                if(popupIndex == 0)
                {
                    if (controls.Player.Tutorial.ReadValue<bool>())
                    {
                        popupIndex++;
                    }

                }
                break;

            default:
                break;

        }

    }
}
