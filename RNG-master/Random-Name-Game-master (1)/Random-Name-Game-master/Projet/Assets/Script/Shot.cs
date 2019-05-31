using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BestMasterYi
{
    public class Shot : MonoBehaviour
    {

        public string perso;
        public int damage;

        /// <summary>
        /// Projectile ami ou ennemi ?
        /// </summary>
        public bool isEnemyShot = false;



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "ground")
                Destroy(gameObject);
        }

        void Start()
        {
            switch (perso)
            {
                case "Tank":
                    damage += PersistantManagerScript.Instance.TankModif[1];
                    break;
                case "Chevalier":
                    damage += PersistantManagerScript.Instance.ChevalierModif[1];
                    break;
                default:
                    damage += PersistantManagerScript.Instance.HeroModif[1];
                    break;
            }
            // 2 - Destruction programmée
            if (gameObject.tag == "Melee")
                Destroy(gameObject, 0.5f);            
        }
        void OnBecameInvisible() {
            Destroy(gameObject);
        }
    }
}