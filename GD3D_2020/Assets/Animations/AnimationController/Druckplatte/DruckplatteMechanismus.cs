using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruckplatteMechanismus : MonoBehaviour
{

    public Animator animator;
    Collider m_ObjectCollider;

    // Start is called before the first frame update

    private void Start()
    { 
        animator = GetComponent<Animator>();
        m_ObjectCollider = GetComponent<Collider>();
        animator.SetBool("isEmpty", false);
        animator.SetBool("isRolling", false);
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Vor If " + other.gameObject.name);
        if (other.gameObject.name == "SFX_INT_RUIN_BOX")
        {
            animator.SetBool("isEmpty", true);
            animator.SetBool("isRolling", true);

        }
    }

   

}
