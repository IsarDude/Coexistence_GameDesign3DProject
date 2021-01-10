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
    public float slowSpeed = 0.5f;
    public float fastSpeed = 2.0f;
    public float height;
    public SpeedEvent slowdown = new SpeedEvent();
    public UnityEvent turnedOffEvent = new UnityEvent();
    public LevitateEvent levitate = new LevitateEvent();
    bool on = false;
    bool playerEntered = false;
    public int onCountdownTime;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    public void SwitchOn()
    {
        Debug.Log("Garvitation field On");
        on = true;
        if (playerEntered)
        {
            levitate.Invoke(height);
        }
        StartCoroutine(CountdownCoroutine());

    }

    IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(onCountdownTime);
        levitate.Invoke(-1f);
        turnedOffEvent.Invoke();
        on = false;
        Debug.Log("Garvitation field off");
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEntered = true;
            if (on)
            {
                levitate.Invoke(height);
            }
            else
            {
                Debug.Log("slowing");
                slowdown.Invoke(slowSpeed);
            }
            }
        }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            playerEntered = false;
            if (!on)
            {
                slowdown.Invoke(fastSpeed);
                Debug.Log("fast");
            }

        }
    }
}
