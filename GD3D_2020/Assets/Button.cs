﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    bool on;
    bool pressable;
    public float facingAngle = 40f;
    public UnityEvent pressedEvent = new UnityEvent();
    GameObject interactor;
    void Start()
    {
        on = false;
        pressable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(interactor != null)
        {
            pressable = CheckIfPlayerIsFacingModel();
            

        }
        if (pressable && !on && Input.GetKeyDown("e"))
        {
            Debug.Log("interact");
            TurnOn();
        }
    }

    bool CheckIfPlayerIsFacingModel()
    {
       
        if(Vector3.Angle(interactor.transform.forward, transform.position - interactor.transform.position) < facingAngle)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Player")
        {
            
            interactor = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactor = null;
        }
    }

    void TurnOn()
    {
        
        pressedEvent.Invoke();
        Debug.Log("PressedOn");
    }

    public void TurnOff()
    {
        on = false;
    }
}
