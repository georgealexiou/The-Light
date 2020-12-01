using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("Winner, winner, chicken dinner!");
            SceneManager.LoadScene(0);
        }
        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : Collided");

        if (player.gameObject.GetComponent<LightBehaviour>().keyCollected == true && player.gameObject.GetComponent<LightBehaviour>().levelHasKey == true){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if(player.gameObject.GetComponent<LightBehaviour>().levelHasKey == false) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
    }
}
