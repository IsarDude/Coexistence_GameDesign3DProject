using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Rigidbody rigidb;
    public float rollingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if(transform.position.y < 10f) {
            
            Vector3 rolling = new Vector3(-rollingSpeed, 0, 0) ;
            rigidb.AddForce(rolling.normalized, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Hitable>().Hit();
        }
    }

    public void StartRolling()
    {
        rigidb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
