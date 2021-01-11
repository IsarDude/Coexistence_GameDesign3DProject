using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : UnityEvent<Key>
{

}
public class Lock : MonoBehaviour
{
    public Unlockable lockedObject;
    GameObject interactor;
    bool locked = true;

    GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(key && interactor && Input.GetKeyDown("e"))
        {
            CheckKey();
        } else if(interactor && Input.GetKeyDown("e"))
        {
            AlertKeyMissing();
        }
        if (!locked)
        {
            Unlock();
        }
    }

    private void AlertKeyMissing()
    {

    }

    private void CheckKey()
    {
        locked = lockedObject.CheckKey(key);
        Debug.Log("lock: " + locked);
    }

    private void Unlock()
    {
        //startAnimation
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactor = other.gameObject;
        }
        if (other.CompareTag("Key"))
        {
            key = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactor = null;
        }
        if (other.CompareTag("Key"))
        {
            key = null;
        }
    }
}
