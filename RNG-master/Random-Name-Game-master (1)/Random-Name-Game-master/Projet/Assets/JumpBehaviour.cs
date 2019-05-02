using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private Transform playerpos;
    public float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerpos = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime); 
        animator.transform.GetComponent<Rigidbody2D>().velocity =
            new Vector2(animator.transform.GetComponent<Rigidbody2D>().velocity.x, 0);
        animator.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <=0) 
            animator.SetTrigger("Idle");        

        else
        {
            timer -= Time.deltaTime;    
        }
        Vector2 target = new Vector2(playerpos.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
