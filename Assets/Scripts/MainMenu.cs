using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int currentLevel = 1;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}