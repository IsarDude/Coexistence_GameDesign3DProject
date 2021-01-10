using System;
using System.Runtime.CompilerServices;
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
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public GameObject otherMainChar;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public colissionEvent colission = new colissionEvent();
    private bool moveable;
    private bool isFloating;
  
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
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;

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
            }
            

        }


        

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer && !isFloating)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
       
        
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        
    }

    public void StopLevitating()
    {
        gravityValue = -9.81f;
        isFloating = false;
    }

    public void Levitate(float maxHeigth)
    {
        if (maxHeigth < 0)
        {
            StopLevitating();
        }
        else { 
            controller.Move( Vector3.up * maxHeigth *Mathf.Cos(Time.deltaTime));
            Debug.Log(transform.position);
            gravityValue = 0f;
            isFloating = true;
        }
    }



    public void ChangePlayerSpeed(float speed)
    {
        this.playerSpeed = speed;
        Debug.Log(playerSpeed);
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