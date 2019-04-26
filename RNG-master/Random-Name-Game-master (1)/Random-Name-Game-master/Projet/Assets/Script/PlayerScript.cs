using System.Collections;
using System.Collections.Generic;
using System.Timers;
using JetBrains.Annotations;
using MyNamespace;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine;

namespace BestMasterYi
{
    public class PlayerScript : MonoBehaviourPun
    {

        public float playerSpeed = 10f;
        public int playerJumpPower = 1250;
        public bool grounded;
        public bool facingRight = false;
        private float moveX;
        public float startTime = 0f;
        float holdTime = 2.0f; // 2 seconds        
        private int DoubleJump = 0;
        public float timer = 0;
        public static GameObject LocalPlayerInstance;
        public float BDashCD;
        public float BDashRate;                
        private Vie barmanager;        

        void Start()
        {   
            BDashCD = 0f;                        
            
        }
        void Awake()
        {
            if ( photonView.IsMine)
            {
                LocalPlayerInstance = gameObject;
            }
// #Critical
// we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(gameObject);
            enabled = photonView.IsMine;
        }
        void Update()
        {            
            if (photonView.IsMine)
            {                
                if (BDashCD > 0)
                {
                    BDashCD -= Time.deltaTime;
                }                              
                if (Input.GetKey(KeyCode.B) & CanBD & grounded)
                {
                    BDashCD = BDashRate;
                    if (facingRight)
                        gameObject.GetComponent<Rigidbody2D>().velocity =
                            new Vector2(-75, 0);
                    else
                    {
                        gameObject.GetComponent<Rigidbody2D>().velocity =
                            new Vector2(75, 0);                        
                    }
                }
                else
                {
                    PlayerMove();
                    timer = Time.time;
                    if (Input.GetButtonDown("Fire1"))
                    {
                        startTime = Time.time + holdTime;
                    }

                    if (Input.GetButtonUp("Fire1") && startTime >= 0.1f)
                    {
                        shot();
                        startTime = 0f;
                    }
                }
                transform.GetComponent<Vie>().getBar().GetComponent<HPBAR>().SetSize(transform.GetComponent<Vie>().getx()*transform.GetComponent<Vie>().hp);
            }
        }    
        void shot()
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
                Sound.Instance.MakePlayerShotSound();
            }
        }        
        void PlayerMove()
        {
            moveX = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && DoubleJump <= 1)
                Jump();
            
            if (Input.GetButtonUp("Jump"))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            }

            if (moveX > 0.0f && facingRight == false)
            {
                FlipPlayer();
                
            }
            else if (moveX < 0.0f && facingRight == true)
            {
                FlipPlayer();
                
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed,
                gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        void Jump()
        {
            grounded = false;   
           
            if (DoubleJump == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
                DoubleJump += 1;
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
                DoubleJump += 1;
            }
        }

        void FlipPlayer()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
           
            if (col.gameObject.tag == "ground")
            {                
                grounded = true;
                DoubleJump = 0;                
            }
        } 
        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
                stream.SendNext(GetComponent<Rigidbody2D>().position);
            else
                GetComponent<Rigidbody2D>().position = (Vector3)stream.ReceiveNext();
        }
        
        public bool CanBD
        {
            get { return BDashCD <= 0f; }
        }
        
    }
}