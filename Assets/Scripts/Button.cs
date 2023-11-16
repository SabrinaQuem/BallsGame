using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Button : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayAgain()
    {
        ScoreManager.Instance.ResetScore();
        Invoke("LoadSampleScene", 0.5f); // Delay the scene loading by 0.1 seconds
    }

    private void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
