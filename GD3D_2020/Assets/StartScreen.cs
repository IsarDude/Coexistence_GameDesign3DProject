using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startScreen;
    public bool GameIsPaused = false;

    public void Resume()
    {
        Time.timeScale = 1f;
        startScreen.SetActive(false);
        GameIsPaused = false;
    }
    public void Pause()
    {
        startScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
