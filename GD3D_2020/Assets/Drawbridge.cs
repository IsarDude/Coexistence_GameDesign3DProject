using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : MonoBehaviour
{
    Animator anim;
    public Drawbridge mirror;
    public Unlockable aUnlockable;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!aUnlockable.locked)
        {

            LetBridgeDown();
        }
    }

    public void LetBridgeDown()
    {
        anim.SetTrigger("LetBridgeDown");
        if(mirror != null)
        {
            mirror.LetBridgeDown();
        }
    }
}
