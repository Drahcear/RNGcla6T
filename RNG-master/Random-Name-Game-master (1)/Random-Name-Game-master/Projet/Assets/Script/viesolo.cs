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
        private soloPlayer player;
        public float health;
        public string perso;
        private float maxhealth;

        void Start()
        {
          Physics2D.IgnoreLayerCollision(8,9);  
          player = GameObject.FindGameObjectWithTag("player").GetComponent<soloPlayer>();
          switch (perso)
          {
            case "Boss":
                break;
            default:
                health += PersistantManagerScript.Instance.HeroModif[0];
                break;
          }

            maxhealth = health;
        }

        // Update is called once per frame
        void Update()
        {
            bar.value = health/maxhealth;
            if (recovery > 0)
            {
                recovery -= Time.deltaTime;
            }      
            
        }                               

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (transform.gameObject.tag == "player" && other.gameObject.tag=="BossCollider")
            {
                if (recovery <= 0)
                {
                    health -= 30;
                    recovery = 1.5f;
                    player.GetComponent<UnityEngine.Animation>().Play("Dmgtaken");
                    StartCoroutine(player.Knockback(0.02f, 150,player.transform.position));
                    
                }                                
            }
            Shot shot = other.gameObject.GetComponent<Shot>();
            if (shot != null)
            {
                // Tir allié
                if (shot.isEnemyShot != isEnemy)
                {
                    health -= shot.damage;
                    // Destruction du projectile
                    // On détruit toujours le gameObject associé
                    if (other.gameObject.tag=="Bullet")

                    Destroy(shot.gameObject);
                }
            }                                
        }                        
    }
}
