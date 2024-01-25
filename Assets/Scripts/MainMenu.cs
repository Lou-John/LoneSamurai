using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int currentLevel = 1;

    void Start()
    {
        MyEvents.SomeEvent += OnSomeEvent;
    }

    private void OnSomeEvent(int value)
    {
        currentLevel = value + 1;
        PlayGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
