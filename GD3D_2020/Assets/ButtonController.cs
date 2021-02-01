using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent pressedEvent = new UnityEvent();
    public Button but;
    public GameObject buttonOn;
    public GameObject buttonOff;
    bool isOn = false;
    public AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (but.on)
        {
            isOn = true;
            buttonOff.GetComponent<Animator>().SetTrigger("TurnOn");
            but.on = false;
        }
       
       
    }
    
    public void SwapModelsToOn()
    {
        manager.Play("Knopf");
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        pressedEvent.Invoke();
    }

    public void SwapModelsToOff()
    {
        manager.Play("Knopf2");
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
    }

    public void NotifyButtonOn()
    {
        but.TurnOn();
    }
}
