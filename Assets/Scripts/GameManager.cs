using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player player;
    protected LightBehaviour light;

    public void onLevelCompletion()
    {
        Debug.Log("Level Complete");
        player.enabled = false;
        light.enabled = false;
    }

    public void onLevelFailure()
    {
        Debug.Log("Level Failed");
        player.enabled = false;
        light.enabled = false;
    }
}
