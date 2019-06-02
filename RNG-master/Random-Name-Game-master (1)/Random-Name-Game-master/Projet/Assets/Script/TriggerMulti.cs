using Photon.Pun;
using UnityEngine;

namespace BestMasterYi
{
    public class TriggerMulti : MonoBehaviourPun
    {

        public GameObject Collider;
        public bool test;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (test)
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("Trigger", RpcTarget.All, null);
                }
                else
                {
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("AntiTrigger", RpcTarget.All, null);
                }

                test = !test;
            }            
            
        }

        [PunRPC]
        void Trigger()
        {
            Collider.SetActive(true);
            
        }
        [PunRPC]
        void AntiTrigger()
        {
            Collider.SetActive(false);
            
        }
    }
}
