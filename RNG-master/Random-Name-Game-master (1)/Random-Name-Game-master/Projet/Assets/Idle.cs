﻿using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private Transform playerpos;
    public float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer = Random.Range(minTime, maxTime); 
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                animator.SetTrigger("Shot2");
            }
            else
            {                                    
                animator.SetTrigger("Shot1");                
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
