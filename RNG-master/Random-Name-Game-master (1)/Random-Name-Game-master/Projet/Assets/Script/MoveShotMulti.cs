using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{



    public class MoveShotMulti : MonoBehaviour
    {
        // 1 - Designer variables

        /// <summary>
        /// Vitesse de déplacement
        /// </summary>        
        private bool facingright = true;
        private GameObject player;        

        private Vector2 movement;

        private void Start()
        {
            player = GameObject.FindWithTag("player");
            
            if (player.GetComponent<PlayerScript>().facingRight!=facingright)
                FlipPlayer(); 
        }

        void Update()
        {
            if (facingright)
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(15,transform.GetComponent<Rigidbody2D>().position.y);
            else
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-15,transform.GetComponent<Rigidbody2D>().position.y);
            }
        }

        void FlipPlayer()
        {
            facingright = !facingright;
            transform.Rotate(0f, 180f, 0f);
        }

        
    }


}