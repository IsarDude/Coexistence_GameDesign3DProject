using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    bool on;
    bool isCollectable;
    bool isCollected;
    public float facingAngle = 250f;
    public UnityEvent pickup = new UnityEvent();
    GameObject interactor;
    Transform TransformOfCarrypoint;
    public Rigidbody collectableBody;
    public HingeJoint hinge;
    public MeshCollider meshCollider;

    public Animator animProf;
    public Animator animAdv;
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
        }
        else
        {
            isCollectable = false;
        }
        if (isCollectable && !on && Input.GetKeyDown("e"))
        {
            animAdv.SetTrigger("triggerInteracting");
            animProf.SetTrigger("triggerInteracting");
            PickingThisUp();
        }
        if (isCollectable && !isCollected)
        {
            Component halo = GetComponent("Halo"); 
            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        }
        else
        {
            Component halo = GetComponent("Halo");
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        }
    }

    

    void PickingThisUp()
    {
        
        this.transform.position = TransformOfCarrypoint.position;
        meshCollider.enabled = false;
        hinge = this.gameObject.AddComponent<HingeJoint>();
        hinge.connectedBody = TransformOfCarrypoint.GetComponent<Rigidbody>();
        isCollected = true;
        //this.transform.parent = interactor.transform;
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            interactor = other.gameObject;
            TransformOfCarrypoint = interactor.transform.GetChild(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            interactor = null;
        }
    }
}
