using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public void OnMenuButtonClicked()
    {
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnPlayGame()
    {
        FindObjectOfType<AudioManager>().Play("click_play");
        SceneManager.LoadScene("Level1");
    }
    public void OnReplayButtonClicked()
    {
        FindObjectOfType<AudioManager>().Play("click_play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnWrong()
    {
        FindObjectOfType<AudioManager>().Play("die");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // QUIT BUTTON - CLOSE GAME
    public void OnQuitButtonClicked()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            FindObjectOfType<AudioManager>().Play("click");
            Application.Quit();
        }
    }
}
