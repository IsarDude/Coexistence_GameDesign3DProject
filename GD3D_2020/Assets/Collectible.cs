using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    bool on;
    bool isCollectable;
    bool isCollected;
    public float facingAngle = 40f;
    public UnityEvent pickup = new UnityEvent();

    GameObject interactor;
    Transform TransformOfCarrypoint;
    public Rigidbody collectableBody;
    public HingeJoint hinge;
    public MeshCollider meshCollider;
    void Start()
    {
        on = false;
        isCollectable = false;
        isCollected = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
            return;
        if (interactor != null)
        {
            isCollectable = true;
            Debug.Log("collectable");

        }
        if (isCollectable && !on && Input.GetKeyDown("e"))
        {
            
            PickingThisUp();
        }
    }

    bool CheckIfPlayerIsFacingModel()
    {

        if (Vector3.Angle(interactor.transform.forward, transform.position - interactor.transform.position) < facingAngle)
        {
            return true;
        }
        return false;
    }

    void PickingThisUp()
    {
        
        this.transform.position = TransformOfCarrypoint.position;
        meshCollider.enabled = false;
        hinge = this.gameObject.AddComponent<HingeJoint>();
        hinge.connectedBody = TransformOfCarrypoint.GetComponent<Rigidbody>();
        //this.transform.parent = interactor.transform;
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            interactor = other.gameObject;
            TransformOfCarrypoint = interactor.transform.GetChild(0);
            Debug.Log(interactor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            interactor = null;
        }
    }
}
