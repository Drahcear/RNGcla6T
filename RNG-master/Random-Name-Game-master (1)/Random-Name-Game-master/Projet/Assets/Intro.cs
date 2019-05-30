using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : StateMachineBehaviour
{
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 3);
        if (rand == 0)
        {
            animator.SetTrigger("Shot2");
        }
        else
        {
            if (rand == 1)
            animator.SetTrigger("Shot1");
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}


