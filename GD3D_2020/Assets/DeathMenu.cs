using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
   public GameObject deathMenu;
    AudioManager manager;

    private void Start()
    {
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void Dead() {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        manager.Play("Tot");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
