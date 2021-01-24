using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalPlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CharacterController controller1;
    public CharacterController controller2;
    bool sleeping = false;
    public float gravityValue = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && !sleeping)
        {
       
            SwitchPlayerPosition();
        }
       

        
    }

    void SwitchPlayerPosition()
    {
        controller1.enabled = false;
        controller2.enabled = false;
        Vector3 position1 = player1.transform.position;
        Vector3 position2 = player2.transform.position;
        Debug.Log("pos1: " + position1);
        Debug.Log("pos2: " + position2);

        player1.transform.position = position2;
        player2.transform.position = position1;
        controller1.enabled = true;
        controller2.enabled = true;
        StartCoroutine(Sleep());
        

    }

    IEnumerator Sleep()
    {
        sleeping = true;
        Debug.Log("SwitchingSleep");
        yield return new WaitForSeconds(1);
        sleeping = false;
    }
}
