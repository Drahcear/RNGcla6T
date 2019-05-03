using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{



    public class MoveScript : MonoBehaviour
    {
        // 1 - Designer variables

        /// <summary>
        /// Vitesse de déplacement
        /// </summary>
        public Vector2 speed = new Vector2(10, 10);
        private bool facingright = true;
        private GameObject player;
        public Vector2 direction = new Vector2(-1, 0);

        private Vector2 movement;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("player");
            
            if (player.GetComponent<soloPlayer>().facingRight!=facingright)
                FlipPlayer(); 
        }

        void Update()
        {
            if( facingright)
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