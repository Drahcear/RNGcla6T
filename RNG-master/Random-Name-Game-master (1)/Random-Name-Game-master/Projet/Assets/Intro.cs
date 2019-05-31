using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : StateMachineBehaviour
{
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 4);
        if (rand == 0)
        {
            animator.SetTrigger("Shot2");
        }
        if (rand == 1)
        {
            animator.SetTrigger("Shot1");
        }

        if (rand == 2)
        {
            animator.SetTrigger("Idle");
        }

        if (rand == 3)
        {
            animator.SetTrigger("Shot3");
        }
    }
    


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}


