using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawbridgeMechanik : MonoBehaviour
{
    public GameObject unlocked;
    public Lock aLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aLock.open)
        {
            unlocked.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }


}
