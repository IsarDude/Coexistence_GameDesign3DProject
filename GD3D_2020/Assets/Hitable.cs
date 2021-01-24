using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitable : MonoBehaviour
{
   public DeathMenu menu;
    public CharacterController contr;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        menu.Dead();
    }



}
