using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject endMenu;

    public void Pause()
    {
        endMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        endMenu.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
