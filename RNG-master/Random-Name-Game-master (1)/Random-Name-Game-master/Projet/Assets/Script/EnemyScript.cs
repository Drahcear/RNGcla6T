using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Comportement générique pour les méchants
/// </summary>
namespace BestMasterYi
{
    public class EnemyScript : MonoBehaviour


    {
        public float speed=1;
        public int xMoveDirection;
        public bool facingright;

        

        void Awake()
        {
            // Récupération de l'arme de l'ennemi
            
        }

        void Start()
        {
            
        }

        void Flip()
        {
            facingright = !facingright;
            transform.Rotate(0f, 180f, 0f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                if (gameObject.GetComponent<Rigidbody2D>().position.x > GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody2D>().position.x) 
                {
                    xMoveDirection = -1;
                }
                
                if (gameObject.GetComponent<Rigidbody2D>().position.x <= GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody2D>().position.x)
                {
                    xMoveDirection = 1;
                }                             
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                xMoveDirection = 0;
                
            }
            
        }

        void Update()
        {    
            //mouvement de l'ennemie
           
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * speed;
            if (xMoveDirection > 0.0f && facingright == false)
            {
                Flip();

            }
            else if (xMoveDirection < 0.0f && facingright == true)
            {
                Flip();

            }
            
            /*foreach (EnnemyShotScript weapon in weapons)
            {
                // On fait tirer toutes les armes automatiquement
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }*/
            
        }
        public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
        {

            float timer = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            while (knockDur > timer)
            {

                timer += Time.deltaTime;

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-knockbackDir.x , -knockbackDir.y + knockbackPwr, transform.position.z));

            }

            yield return 0;

        }

    
    }
}