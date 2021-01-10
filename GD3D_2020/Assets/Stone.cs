using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRolling()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
