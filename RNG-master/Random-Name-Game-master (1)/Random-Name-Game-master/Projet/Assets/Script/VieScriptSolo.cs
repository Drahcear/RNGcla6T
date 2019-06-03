using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{



    public class VieScriptSolo : MonoBehaviour
    {


        public float hp;

        public bool isEnemy;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (hp <= 0)
            {
                transform.GetComponent<Loot>().Lootboxinterditenbelgique();
                Destroy(transform.parent.gameObject);
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
                    hp -= shot.damage;

                   
                }
            }
        }
    }
}
    
