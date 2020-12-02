using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject completeLevelUI;
    private GameObject player;
    private bool keyCollected, levelHasKey;

    public void Start()
    {
        completeLevelUI.SetActive(false);

        player = GameObject.Find("Player");
        levelHasKey = player.GetComponent<LightBehaviour>().levelHasKey;
        keyCollected = player.GetComponent<LightBehaviour>().keyCollected;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyCollected = player.GetComponent<LightBehaviour>().keyCollected;

        if (!levelHasKey || keyCollected)
        {
            FindObjectOfType<SoundManager>().Play("Completed");
            completeLevelUI.SetActive(true);


            Time.timeScale = 1f;
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<LightBehaviour>().enabled = false;
        }
       
    }
}
