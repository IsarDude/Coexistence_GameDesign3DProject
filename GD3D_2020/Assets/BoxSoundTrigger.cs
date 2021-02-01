using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundTrigger : MonoBehaviour
{
    public Rigidbody rig;
    public AudioManager audioPlayer;
    bool soundStartet = false;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if(rig.velocity.magnitude > 0)
        {
            StartGrindSound();
        }
        else
        {
            PauseGrindSound();
        }
    }

    void StartGrindSound()
    {
        if (!soundStartet)
        {
            audioPlayer.Play("Grind");
            soundStartet = true;
        }
           
    }

    void PauseGrindSound()
    {
        audioPlayer.Pause("Grind");
        soundStartet = false;
    }
}
