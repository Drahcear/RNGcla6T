using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BestMasterYi
{



    public class BackDash : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody2D rb;
        public float Bdash;
        private float BdashTime;
        public float startDashTime;
        private int direction;
        private Animator Animé;    

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            BdashTime = startDashTime;
            Animé = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (direction == 0)
            {
                
                if (Input.GetKey(KeyCode.B))
                {
                    
                    direction = 1;
                }
            }
            else
            {
                if (BdashTime <= 0)
                { 
                    Animé.SetTrigger("Backdash");
                    direction = 0;
                    Bdash = startDashTime;
                    rb.velocity = Vector2.zero;
                    
                    
                    
                }

                else
                {
                    BdashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        rb.velocity = new Vector2(Bdash, 0);
                        
                        
                    }
                }
            }
        }
    }
}