using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public IslandBehav islandBehav;

    private void Awake()
    {
        islandBehav.isNewestIsland = true;
        islandBehav.IslandsPresent = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void RestartDelay()
    {
        Invoke(nameof(Restart), 2);
    }
    
    public void Restart()
    {
        print("asdfasd");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }
}