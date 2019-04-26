using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BestMasterYi
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
    
        public GameObject PlayerPrefab;
        public GameObject mob;        
        
        public List<GameObject> Prefabs;
        [HideInInspector] public string localPlayer;

        private void Awake()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LoadLevel("Menu");                                                 
            }
        }

        
        void Start()
        {
            foreach (var p in Prefabs)
            {
                if (p.name == PersistantManagerScript.Instance.perso)
                    PlayerPrefab = p;
            }
            if (PlayerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
            }
            else
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                if (PlayerScript.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                      PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(
                        -3f, 2f, 1f), Quaternion.identity, 0);
                    if (PhotonNetwork.IsMasterClient)
                    {
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            -9.712f, -12.124f, 1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            -9.13f , -1.68f , 1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            11.59f, -4.01f,1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            14.22f, 2.19f,1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            11.23f, 10.28f,1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            2.84f, 15.09f,1f), Quaternion.identity, 0);
                        
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            14f, 27.4f,1f), Quaternion.identity, 0);    
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            2.6f, 34.1f,1f), Quaternion.identity, 0);
                        PhotonNetwork.Instantiate(mob.name, new Vector3(
                            -13.7f,49.1f,1f), Quaternion.identity, 0);
                        Debug.Log("true");
                    }
                    

                    
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }

        public override void OnJoinedRoom()
        {            
        }

        // Update is called once per frame
        void Update()
        {

        }        
    }
}