using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace BestMasterYi
{

    public class DialogHolder : MonoBehaviour
    {
        public string dialogue;

        private DialogueManager dMan;
        private bool ev = false;
        public string[] ENdiaLines;
        public string[] FRdiaLines;
        private string[] diaLines;

        // Start is called before the first frame update
        void Start()
        {
            switch (PersistantManagerScript.Instance.language)
            {
                case "en":
                    diaLines = ENdiaLines;
                    break;
                default:
                    diaLines = FRdiaLines;
                    break;
            }
            dMan = FindObjectOfType<DialogueManager>();
            if (transform.gameObject.tag == "Dialogevent")
            {
                ev = true;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay2D(Collider2D other)
        {
       
            if (other.gameObject.tag == "player")
            {
                if (Input.GetKeyUp(KeyCode.L))
                {
                    //dMan.showbox(dialogue);

                    if (!dMan.DialogActive)
                    {
                        dMan.DialogLines = diaLines;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();
                    }
                }

                if (ev)
                {
                    if (!dMan.DialogActive)
                    {
                        dMan.DialogLines = diaLines;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();
                        ev = !ev;
                    }
                }
            }
        }
    }
}