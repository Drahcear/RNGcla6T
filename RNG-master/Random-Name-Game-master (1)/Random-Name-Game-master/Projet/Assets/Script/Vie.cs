using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using Photon.Pun;
using UnityEngine;

namespace BestMasterYi
{
    public class Vie : MonoBehaviour
    {
        private float maxHp;
        public string perso;
        public float hp;
        public bool isEnemy = true;
        private GameObject bar;
        private double dmgtobar;
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
                default:
                    hp += PersistantManagerScript.Instance.HeroModif[0];
                    break;
            }
            
            
            player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerScript>();
        }
        

        public float getx()
        {
            return x;
        }

        public GameObject getBar()
        {
            return bar;
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
                    if (transform.gameObject.tag == "Méchant")
                    {
                        //transform.GetComponent<UnityEngine.Animation>().Play("Dmgtaken");
                        StartCoroutine(transform.gameObject.GetComponent<EnemyScript>().Knockback(0.05f, 150,transform.position));
                    }
                    if (other.gameObject.tag == "Bullet")

                        Destroy(shot.gameObject);
                }
                if (hp <= 0)
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("DestroyTarget", RpcTarget.All, null);
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collider)
        {                                    
            if (transform.gameObject.tag == "player" && collider.gameObject.CompareTag("Méchant"))
            {
                hp -= 1;
                player.GetComponent<UnityEngine.Animation>().Play("DmgTaken");
                StartCoroutine(player.Knockback(0.02f, 150,player.transform.position));
            }

            if (hp <= 0)
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("DestroyTarget", RpcTarget.All, null);
            }

//            bar.GetComponent<HPBAR>().SetSize(x * hp);
        }
    

    [PunRPC]
        void DestroyTarget()
        {
            if (transform.gameObject.tag == "player")
            {
                Sound.Instance.DeathSound();
                transform.position = new Vector3(-3f, 2f, 1f);
                hp = maxHp;
                bar.GetComponent<HPBAR>().SetSize(x*hp);
            }
            else
            {
                Sound.Instance.MakeCreepDeath();  
                Destroy(gameObject);
            }
        }
    }

}