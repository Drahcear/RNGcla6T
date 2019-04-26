using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;

namespace BestMasterYi
{



    public class Initdialog : MonoBehaviour
    {
        public bool dialogActive;
        public GameObject dialogbox;

        public GameObject dialogmanager;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L) && dialogActive)
            {
                if (dialogbox.activeInHierarchy)
                {
                    dialogbox.SetActive(false);
                    dialogmanager.SetActive(false);                    

                }
                else
                {
                    dialogbox.SetActive(true);
                    dialogmanager.SetActive(true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                Debug.Log("in");
                dialogActive = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                Debug.Log("left");
                dialogActive = false;
                dialogbox.SetActive(false);
                dialogmanager.SetActive(false);
            }
        }
    }
}