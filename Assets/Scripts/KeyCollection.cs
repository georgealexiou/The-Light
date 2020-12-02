using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{

    public GameObject player;
    public GameObject exit;

    public void Start()
    {
        exit = GameObject.Find("NewExit");
        player = GameObject.Find("Player");

        exit.GetComponent<SpriteRenderer>().color = Color.black;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<SoundManager>().Play("Key");
        Color color = player.GetComponent<LightBehaviour>().gradient1.Evaluate(0f);
        exit.GetComponent<SpriteRenderer>().color = color;

        if (collision.gameObject.tag.Equals("Player"))
        {
            player.gameObject.GetComponent<LightBehaviour>().keyCollected = true;
            gameObject.SetActive(false);
        }
    }
}
