using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int currentLevel = 1;

    private void Start()
    {
        MyEvents.SomeEvent += OnSomeEvent;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(currentLevel);
    }

    private void OnSomeEvent(int value)
    {
        currentLevel = value + 1;
        PlayGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
