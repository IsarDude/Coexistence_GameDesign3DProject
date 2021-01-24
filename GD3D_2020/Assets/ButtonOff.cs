using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOff : MonoBehaviour
{
    public ButtonController parentObjectController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotifyAnimationEnded()
    {
        parentObjectController.SwapModelsToOn();
    }
}
