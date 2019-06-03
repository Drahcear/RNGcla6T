using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

namespace BestMasterYi
{
    public class Vie : MonoBehaviourPun
    {
        private float maxHp;
        public string perso;
        public float hp;
        public bool isEnemy = true;
        public GameObject slider;        
        private float x;
        private PlayerScript player;
        private string scene = "MainMenu";

        void Start()
        {
            switch (perso)
            {
                case "Tank":
                    hp += PersistantManagerScript.Instance.TankModif[0];
                    break;
                case "Chevalier":
                    hp += PersistantManagerScript.Instance.ChevalierModif[0];
                    break;
                case "Demon":
                    hp += PersistantManagerScript.Instance.DemonModif[0];
                    break;
                default:
                    hp += PersistantManagerScript.Instance.HeroModif[0];
                    break;
            }

            maxHp = hp;
            if (transform.gameObject.tag == "player")
            {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>();
            
            
                slider = GameObject.FindGameObjectWithTag("Slider");
            }
        }

        private void Update()
        {
            if (transform.gameObject.tag =="player")
            slider.GetComponent<Slider>().value = hp/maxHp;
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
                    if (transform.gameObject.tag == "player")
                    {
                        player.GetComponent<UnityEngine.Animation>().Play("Dmgtaken");
                        StartCoroutine(player.Knockback(0.02f, 150,player.transform.position));
                    }
                   

                    if (other.gameObject.tag == "Bullet")

                        Destroy(shot.gameObject);
                }
                if (hp <= 0)
                {
                    if (transform.parent.gameObject.tag == "Méchant")
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("DestroyTarget", RpcTarget.All, null);
                    }
                    else
                    {
                        PhotonView photonView = PhotonView.Get(this);
                        photonView.RPC("DestroyTarget", RpcTarget.All, null);
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collider)
        {                                    
            if (transform.gameObject.tag == "player" && collider.gameObject.CompareTag("Méchant"))
            {
                hp -= 10;
                player.GetComponent<UnityEngine.Animation>().Play("DmgTaken");
                StartCoroutine(player.Knockback(0.02f, 150,player.transform.position));
            }

            if (hp <= 0)
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("DestroyTarget", RpcTarget.All, null);
            }

        }
    

    [PunRPC]
        void DestroyTarget()
        {
            if (transform.gameObject.tag == "player")
            {
                
                transform.position = new Vector3(-3f, 2f, 1f);
                hp = maxHp;                
            }
            else
            {
                transform.GetComponent<Loot>().Lootboxinterditenbelgique();
                Destroy(transform.parent.gameObject);
            }
        }
    }

}