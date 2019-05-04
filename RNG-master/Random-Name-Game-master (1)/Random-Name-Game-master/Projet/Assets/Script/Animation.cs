using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{
    public class Animation : MonoBehaviour
    {
        private Animator Animé;        

        // Start is called before the first frame update
        void Start()
        {            
            Animé = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                Animé.SetBool("IsRunning",true);                                                    
            else
            {
                Animé.SetBool("IsRunning",false);
            }            
            if (Input.GetKeyDown(KeyCode.Space))
                Animé.SetTrigger("IsAttacking");
            else
            {
                Animé.SetBool("IsAttacking",false);
            }
        }
    }
}