using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStateMaschine : StateMachineBehaviour
{
    public ButtonController butCo;
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        butCo.NotifyButtonOn();
    }

}
