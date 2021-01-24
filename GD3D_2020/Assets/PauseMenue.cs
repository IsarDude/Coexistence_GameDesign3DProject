using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
   public static bool GameIsPaused = false;

    public GameObject pausemenueUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       
        }


    public void Resume()
    {
        Time.timeScale = 1f;
        pausemenueUI.SetActive(false);
        GameIsPaused = false;
    }
    public void Pause()
        {
            pausemenueUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

    public void Reload()
    {
        Resume();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    }

