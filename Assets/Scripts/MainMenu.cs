using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void TutorialGame()
    {
        SceneManager.LoadScene("MovementScene2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void loadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("TtitleScreenWIP");
    }

    public void loadNext()
    {
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            loadMainMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
 