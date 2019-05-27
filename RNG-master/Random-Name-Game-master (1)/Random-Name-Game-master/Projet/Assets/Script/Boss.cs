using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;
using UnityEngine.UI;

namespace BestMasterYi
{
    public class Boss : MonoBehaviour
    {
        private Animator animé;
        public GameObject last;
        



        private void Start()
        {
            animé = GetComponent<Animator>();
        }

        private void Update()
        {
            if (GetComponent<viesolo>().health <= 500)
            {
                animé.SetTrigger("Stage2");
            }

            if (GetComponent<viesolo>().health <= 0)
            {
                animé.SetTrigger("Dead");
                
    
                Destroy(gameObject,1f) ;
                
                last.SetActive(true);
                
            }
        }
    }
}