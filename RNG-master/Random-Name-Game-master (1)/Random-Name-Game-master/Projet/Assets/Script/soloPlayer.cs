using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace BestMasterYi
{
    public class soloPlayer : MonoBehaviour
    {

        public float playerSpeed = 10f;
        public int playerJumpPower = 1250;
        public bool grounded;
        public bool facingRight = false;
        private float moveX;
        public float startTime = 0f;
        float holdTime = 1.5f; // 2 seconds        
        private int DoubleJump = 0;
        public float timer = 0;
        public float BDashCD;
        public float BDashRate;
        public GameObject Equipement;
        public GameObject Inventory;
        private bool windowsOpen = false;
        private bool dmg;
        private Animator Animé;


        void Start()
        {
            BDashCD = 0f;
            Animé = GetComponent<Animator>();
            
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) & windowsOpen == false)
            {
                Equipement.SetActive(true);
                Inventory.SetActive(true);
                windowsOpen = true;

            }
            else if (Input.GetKeyDown(KeyCode.P) & windowsOpen == true)
            {
                Equipement.SetActive(false);
                Inventory.SetActive(false);
                windowsOpen = false;
            }

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

            if (grounded)
            {
                Animé.SetBool("Jumping", false);
                Animé.SetBool("grounded", true);
            }
        }

        void shot()
        {
            soloweapon weapon = GetComponent<soloweapon>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
                //Sound.Instance.MakePlayerShotSound();
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
            Animé.SetBool("Jumping",true);
            Animé.SetBool("grounded", false);
            
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

            Debug.Log(col.gameObject.tag);
        }



        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
                stream.SendNext(GetComponent<Rigidbody2D>().position);
            else
                GetComponent<Rigidbody2D>().position = (Vector3) stream.ReceiveNext();
        }

        public bool CanBD
        {
            get { return BDashCD <= 0f; }
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
