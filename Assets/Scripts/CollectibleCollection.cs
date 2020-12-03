using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCollection : MonoBehaviour
{

    private GameObject player;
    public TMP_Text text;

    public void Start()
    {
        player = GameObject.Find("Player");

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<SoundManager>().Play("Collectible");
            player.GetComponent<Player>().collectible++;
            text.text = player.GetComponent<Player>().collectible + "";
            gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        Vector3 rotation = new Vector3(0f, 0f, 50f);
        transform.Rotate(rotation * Time.deltaTime);
    }

}
