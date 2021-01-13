using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Animator anim;
    public bool broken = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BreakableTrigger"))
        {
            Debug.Log("PillarIsBreaking");

            broken = true;
            anim.SetBool("broken", broken);
        }
    }
}
