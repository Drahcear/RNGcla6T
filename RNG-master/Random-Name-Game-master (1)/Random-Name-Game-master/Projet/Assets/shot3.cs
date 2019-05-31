using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;

public class shot3 : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private Transform playerpos;
    public float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer = Random.Range(minTime, maxTime); 
        animator.transform.GetComponent<Boss2IA>().Attack3();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                animator.SetTrigger("Shot1");
            }
            if (rand ==1)
            {                                    
                animator.SetTrigger("Idle");                
            }

            if (rand == 2)
            {
                animator.SetTrigger("Shot2");
            }
        }

        else
        {
            timer -= Time.deltaTime;    
        }
       
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
