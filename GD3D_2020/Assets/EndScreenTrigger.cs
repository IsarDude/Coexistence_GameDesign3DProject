using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    public EndScreen endScreen;

    private void OnTriggerEnter(Collider other)
    {
        endScreen.Pause();
        this.gameObject.SetActive(false);
    }
}
