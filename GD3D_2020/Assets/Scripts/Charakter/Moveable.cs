﻿using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class colissionEvent: UnityEvent<bool>
{
}
public class Moveable : MonoBehaviour
{
    public CharacterController controller;
    public GameObject otherObject;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 0.5f;
    private float gravityValue = -9.81f;
    private bool pushing = false;

    public GameObject otherMainChar;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public colissionEvent colission = new colissionEvent();
    private bool moveable;
    private bool isFloating;

    public Animator anim;
    public AudioManager audi;
  
    private void Start()
    {
        moveable = true;
        isFloating = false;
    }

    void Update()
    { 
        if (isFloating)
        {
            return;
        }
       
        groundedPlayer = controller.isGrounded;
        controller.Move(playerVelocity * Time.deltaTime);
      
        if (groundedPlayer)
        {
            anim.SetBool("isJumping", false);
            if (Input.GetKeyDown("space") && !isFloating)
            {
                playerVelocity.y = 0f;
                Debug.Log("jumping");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                anim.SetBool("isJumping", true);
            }
            else
            {

                playerVelocity.y += -0.000000000000001f * Time.deltaTime;
            }
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
    


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (moveable && !isFloating)
            {
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
                anim.SetBool("isWalking", true);
            }
            

        } else
        {
            anim.SetBool("isWalking", false);
        }



            playerVelocity.y += -0.001f;
            controller.Move(playerVelocity * Time.deltaTime);
            playerVelocity.y += +0.0001f;


        // Changes the height position of the player..







    }

    void ReturnTOyPosition()
    {
        this.controller.enabled = false;
        Vector3 tempVec = transform.position;
        tempVec.y = otherMainChar.transform.position.y;
        transform.position = tempVec;
        this.controller.enabled = true;
    }

    public void StopLevitating()
    {
        gravityValue = -9.81f;
        isFloating = false;
        anim.SetBool("isLevitating", false);
    }

    public void Levitate(float maxHeigth)
    {
        if (maxHeigth < 0)
        {
            StopLevitating();
        }
        else { 
            controller.Move( Vector3.up * maxHeigth *Mathf.Cos(Time.deltaTime));
            Debug.Log(Vector3.up * maxHeigth * Mathf.Cos(Time.deltaTime));
            gravityValue = 0f;
            isFloating = true;
            anim.SetBool("isLevitating", true);
        }
    }



    public void ChangePlayerSpeed(float speed)
    {
        this.playerSpeed = speed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(activeInput())
        {
            Debug.Log("TriggerEnter of" + other.name);
            if (other.gameObject.CompareTag("box_boxcollider"))
            {
                anim.SetBool("isPushing", true);
                
                Debug.Log("Player is Pushing the Box");
               
            }else
            {
                anim.SetBool("isPushing", false);
                Debug.Log("Player Stopped Pushing the Box");
            }
        } else
        {
            anim.SetBool("isPushing", false);
            Debug.Log("Player Stopped Pushing the Box");
        }
        /*Debug.Log("TriggerEnter of" + other.name);
        if (other.gameObject.CompareTag("box_boxcollider"))
        {
            anim.SetBool("isPushing", true);
            Debug.Log("Player is Pushing the Box");
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit of" + other.name );
        if (other.gameObject.CompareTag("box_boxcollider"))
        {
            anim.SetBool("isPushing", false);
            
            Debug.Log("Player Stopped Pushing the Box");
        }
    }

    private Boolean activeInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }

    /*
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.gameObject.tag != "ground")
            {
                otherObject.transform.parent = this.transform;
                colission.Invoke(false);
                Debug.Log("hit");
            }

        }

        private void OnCollisionExit(Collision collision)
        {
             otherObject.transform.parent = this.transform.parent;
            colission.Invoke(true);
            Debug.Log("exited");
        }

        public void OtherObjectHitCollider(bool isMovable)
        {
            moveable = isMovable;
            Debug.Log("handedTochonroller");
        }
    */
}