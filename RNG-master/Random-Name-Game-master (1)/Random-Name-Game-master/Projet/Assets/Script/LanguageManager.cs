using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace BestMasterYi
{
    public class LanguageManager : MonoBehaviour
    {
        public Text ValueTxt;
        public string FR;
        public string EN;
        
        // Start is called before the first frame update
        void Start()
        {
            switch (PersistantManagerScript.Instance.language)
            {
                case "en":
                    ValueTxt.text = EN;
                    break;
                default:
                    ValueTxt.text = FR;
                    break;
            }
        }

        public void SetLanguage(string language)
        {
            PersistantManagerScript.Instance.language = language;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }

}

