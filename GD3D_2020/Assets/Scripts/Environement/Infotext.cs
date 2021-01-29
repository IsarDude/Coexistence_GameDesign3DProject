using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infotext : MonoBehaviour
{
    public GameObject text;
    public bool isInRange;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive) {
            if (isInRange)
            {
                //Show Text
                text.SetActive(true);
            }
            else
            {
                //Hide Text
                text.SetActive(false);
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is within range.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not within range.");
        }
    }

    public void setInactive()
    {
        isActive = false;
    }

    public void disableText()
    {
        text.SetActive(false);
    }

}
