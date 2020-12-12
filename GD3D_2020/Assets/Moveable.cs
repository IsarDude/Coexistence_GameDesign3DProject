using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]

public class Moveable : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Vector3 rotation;
    private float rotationSpeed = 100.0f;
    public GameObject otherMainChar;
    
    private bool stop;
    private void Start()
    {
      
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        rotation = new Vector3(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        Vector3 move = new Vector3(0, -Input.GetAxis("Vertical") * Time.deltaTime, 0);
        move = this.transform.TransformDirection(move);

        if (!stop) { 
        controller.Move(move * playerSpeed);

        this.transform.Rotate(this.rotation);
        }
        stop = false;
        /*
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = new Vector3(move.x,0,move.y);
        }
        */


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }



        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);


    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log( "enterdColission");
        otherMainChar.SendMessage("StopMovement");
    }

    public void StopMovement()
    {
        stop = true;
        Debug.Log(this.name + "stoppedMovment");
    }


}
