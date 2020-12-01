using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject levelFailedUI;
    private GameObject player;

    public void Start()
    {
        completeLevelUI.SetActive(false);
        levelFailedUI.SetActive(false);

        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");

        if (player.GetComponent<LightBehaviour>().keyCollected == true)
        {
            completeLevelUI.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<LightBehaviour>().enabled = false;
        }
    }
}
