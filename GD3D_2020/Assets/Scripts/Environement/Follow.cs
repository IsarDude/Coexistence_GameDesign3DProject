using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject leadingObject;
    private Vector3 leadingObjectPos;

    // Update is called once per frame
    void Update()
    {
        leadingObjectPos = leadingObject.transform.position;
        gameObject.transform.position = leadingObjectPos;
    }
}
