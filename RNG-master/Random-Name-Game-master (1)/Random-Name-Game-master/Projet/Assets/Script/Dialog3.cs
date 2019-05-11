using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BestMasterYi
{
    public class Dialog3 : MonoBehaviour
    {
        public TextMeshProUGUI textDisplay;
        public string[] sentencesEN;
        public string[] sentencesFR;
        private string[] sentences;
        private int index;
        public float typingSpeed;
        public GameObject continueButton;
        public GameObject dialogbox;
        private int count;

        void Start()
        {
            index = 0;       
            switch (PersistantManagerScript.Instance.language)
            {
                case "en":
                    sentences = sentencesEN;
                    break;
                default:
                    sentences = sentencesFR;
                    break;
            }
            count = sentences.Length;
            StartCoroutine(Type());
        }
        
        
        void Update()
        {            
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true); 
            }
        }

        IEnumerator Type()
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        public void NextSentence(Collider2D other)
        {
            if (other.CompareTag("player"))
            {
                continueButton.SetActive(false);
                if (index < count - 1)
                {
                    index += 1;
                    textDisplay.text = "";
                    StartCoroutine(Type());
                }
                else
                {
                    
                    textDisplay.text = "";
                    continueButton.SetActive(false);
                    dialogbox.SetActive(false);
                }
            }
        }
       
    }
}