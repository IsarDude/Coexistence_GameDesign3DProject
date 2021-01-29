using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Rigidbody rigidb;
    public float rollingSpeed;
    public bool rolling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if(transform.position.y < 10f && rolling) {
            
            Vector3 rolling = new Vector3(-rollingSpeed, 0, 0);
            rigidb.AddForce(rolling.normalized, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit");
        if(collision.gameObject.tag == "Player" && rolling)
        {
            collision.gameObject.GetComponent<Hitable>().Hit();
        }
        else if(collision.gameObject.tag != "ground")
        {
            rigidb.velocity = Vector3.zero; 
            rigidb.angularVelocity = new  Vector3(0,0, 0f);
            rigidb.constraints =RigidbodyConstraints.FreezePosition;
            rolling = false;
        }
        

    }

    public void StartRolling()
    {
        rolling = true;
        rigidb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
