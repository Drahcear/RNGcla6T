using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BestMasterYi
{

    public class viesolo : MonoBehaviour
    {
        public Slider bar;
        public bool isEnemy;
        private float recovery;

        public int health;

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            bar.value = health;
            if (recovery > 0)
            {
                recovery -= Time.deltaTime;
            }
            
        }                
        void OnCollisionEnter2D(Collision2D other)
        {            
            if (transform.gameObject.tag == "player" && other.gameObject.tag=="Méchant")
            {
                if (recovery <= 0)
                {
                    health -= 1;
                    recovery = 1.5f;
                }                                
            }
        }
        


        private void OnTriggerEnter2D(Collider2D other)
        {
            Shot shot = other.gameObject.GetComponent<Shot>();
            if (shot != null)
            {
                // Tir allié
                if (shot.isEnemyShot != isEnemy)
                {
                    health -= shot.damage;
                    // Destruction du projectile
                    // On détruit toujours le gameObject associé

                    Destroy(shot.gameObject);
                }
            }
        
        }
    }
}
