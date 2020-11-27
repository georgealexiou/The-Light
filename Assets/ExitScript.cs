using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
        {
            Debug.Log("Winner, winner, chicken dinner!");
            SceneManager.LoadScene(0);
        }
        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : Collided");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
