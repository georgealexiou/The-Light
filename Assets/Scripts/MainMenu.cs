using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Sound();
        SceneManager.LoadScene("FirstLevel");

    }

    public void TutorialGame()
    {
        Sound();
        SceneManager.LoadScene("MovementScene2");
    }

    public void QuitGame()
    {
        Sound();
        Application.Quit();
    }

    public void restartLevel()
    {
        Sound();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void loadLevel(string name)
    {
        Sound();
        SceneManager.LoadScene(name);
    }

    public void loadMainMenu()
    {
        Sound();
        SceneManager.LoadScene("TtitleScreenWIP");
    }

    public void loadNext()
    {
        Sound();
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            loadMainMenu();
        }
        else
        {
            Sound();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void Sound()
    {
        FindObjectOfType<SoundManager>().Play("UI");

    }

    public void changeMasterVolume(float vol)
    {
        FindObjectOfType<SoundManager>().SetVolume("Music", vol);
    }
}
 