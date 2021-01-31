using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public Breakable mirror;
    Animator anim;
    public bool broken = false;

    private bool soundActive = true;

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
            Break();
            if(soundActive)
            {
                FindObjectOfType<AudioManager>().Play("Steinaufschlag");
                Invoke("PlaySäulenSound", 1);
                soundActive = false;
            }
        }
    }

    public void Break()
    {
        broken = true;
        anim.SetBool("broken", broken);
        if(mirror != null)
        {
            mirror.Break();
        }
    }

    private void PlaySäulenSound()
    {
        FindObjectOfType<AudioManager>().Play("Säulenbruch");
    }

}
