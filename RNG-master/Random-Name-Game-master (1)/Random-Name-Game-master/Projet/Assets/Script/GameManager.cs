﻿using System.Collections;
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
                        -3f, 0     , 1f), Quaternion.identity, 0);                                                            
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