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
    // Start is called before the first frame update
    void Start()
    {
        
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
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        pressedEvent.Invoke();
    }

    public void SwapModelsToOff()
    {
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
    }

    public void NotifyButtonOn()
    {
        but.TurnOn();
    }
}
