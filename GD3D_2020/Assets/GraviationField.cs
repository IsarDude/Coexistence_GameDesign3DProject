using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SpeedEvent: UnityEvent<float>
{
}

[System.Serializable]
public class LevitateEvent: UnityEvent<float>
{
}

public class GraviationField : MonoBehaviour
{
    bool up;
    public float slowSpeed = 0.5f;
    public float fastSpeed = 2.0f;
    public float height;
    public SpeedEvent slowdown = new SpeedEvent();
    public LevitateEvent levitate = new LevitateEvent();
    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (up)
        {
            levitate.Invoke(height);
        } else
        {
            Debug.Log("slowing");
            slowdown.Invoke(slowSpeed);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (up)
        {
            return;
        }
            slowdown.Invoke(fastSpeed);
            Debug.Log("fast");
        
     
    }
}
