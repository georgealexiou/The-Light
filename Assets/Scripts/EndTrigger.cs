using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        Debug.Log("eleos");
        gameManager.onLevelCompletion();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("aa");
    //}
}
