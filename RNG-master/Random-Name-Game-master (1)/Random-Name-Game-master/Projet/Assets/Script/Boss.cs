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
        public GameObject sound;
        public GameObject Particle;



        private void Start()
        {
            animé = GetComponent<Animator>();
            sound.SetActive(true);
        }

        private void Update()
        {
            if (GetComponent<viesolo>().health <= 250)
            {
                animé.SetTrigger("Stage2");
                Particle.SetActive(true);
            }

            if (GetComponent<viesolo>().health <= 0)
            {
                animé.SetTrigger("Dead");
                
                last.SetActive(true);
                Destroy(gameObject,1f) ;
                
                
                
            }
        }
    }
}