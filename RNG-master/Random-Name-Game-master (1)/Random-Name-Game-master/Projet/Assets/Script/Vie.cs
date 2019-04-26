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
        public float hp;
        public bool isEnemy = true;
        private GameObject bar;
        private double dmgtobar;
        private float x;
        private string scene = "MainMenu";

        void Start()
        {
            maxHp = hp;
            bar = GameObject.Find("HPBAR");
            dmgtobar = 1.0 / hp;
            x = (float) dmgtobar;
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
                    // Destruction du projectile
                    // On détruit toujours le gameObject associé

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
            }

            if (hp <= 0)
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("DestroyTarget", RpcTarget.All, null);
            }

            bar.GetComponent<HPBAR>().SetSize(x * hp);
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