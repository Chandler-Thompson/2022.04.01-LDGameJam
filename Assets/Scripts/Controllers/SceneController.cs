using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void LoadWinningContent()
    {
        LoadScene("GameDone");
    }

    public void Reset()
    {
        Debug.Log("[SceneController]: Resetting...");
        LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
