using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenTrigger : MonoBehaviour
{
    public StartScreen startScreen;

    private void OnTriggerEnter(Collider other)
    {
        startScreen.Pause();
        this.gameObject.SetActive(false);
    }
}
