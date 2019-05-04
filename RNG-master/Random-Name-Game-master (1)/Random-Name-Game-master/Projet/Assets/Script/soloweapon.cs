using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{
    public class soloweapon : MonoBehaviour
    {

        public Transform shotPrefab;
        public Transform shotPrefab2;
        public  bool facingRight = true;
        public float shootingRate = 0.5f;



        //--------------------------------
        // 2 - Rechargement
        //--------------------------------
        private float shootCooldown;

        void Start()
        {
            shootCooldown = 0f;
        }

        void Update()
        {
            if (shootCooldown > 0)
            {
                shootCooldown -= Time.deltaTime;
            }
             
            if (facingRight != transform.GetComponent<soloPlayer>().facingRight)
                Flip();            
        }



        public void Attack(bool isEnemy)
        {
            if (CanAttack)
            {
                shootCooldown = shootingRate;
                soloPlayer shotType = GetComponent<soloPlayer>();


                if (shotType.timer >= shotType.startTime)
                {
                    var shotTransform = Instantiate(shotPrefab2) as Transform;
                    AttackType(shotTransform);
                    Shot shot = shotTransform.gameObject.GetComponent<Shot>();

                    if (shot != null)
                    {
                        shot.isEnemyShot = isEnemy;
                    }
                }
                else
                {
                    var shotTransform1 = Instantiate(shotPrefab) as Transform;
                    AttackType(shotTransform1);
                    
                    Shot shot = shotTransform1.gameObject.GetComponent<Shot>();

                    if (shot != null)
                    {
                        shot.isEnemyShot = isEnemy;
                    }
                }                              
            }
        }

        void AttackType(Transform t)
        {
            if (t.tag == "Melee" && facingRight)
            {
                
                t.position = new Vector3(transform.position.x + 1.5f, transform.position.y+0.1f, transform.position.z);
                
            }
            else if (t.tag == "Melee" && facingRight == false)
            {
                t.position = new Vector3(transform.position.x - 1.5f, transform.position.y-0.1f, transform.position.z);
            }
            else if (t.tag == "Bullet" && facingRight == false)
            {
                t.position = new Vector3(transform.position.x -0.5f, transform.position.y, transform.position.z);
            } 
            else if (t.tag == "Bullet" && facingRight == true)
                t.position = new Vector3(transform.position.x +0.5f, transform.position.y, transform.position.z);
        }

        public bool CanAttack
        {
            get { return shootCooldown <= 0f; }
        }

        void Flip()
        {
            facingRight = !facingRight;
            shotPrefab.Rotate(0f, 180f, 0f);
        }

    }
}