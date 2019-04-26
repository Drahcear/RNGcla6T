using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BestMasterYi
{
    public class POPUP : MonoBehaviour
    {
        private Text dmg;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 0.5f);
            dmg = gameObject.GetComponent<Text>();
        }

        // Update is called once per frame
        public void SetText(string text)
        {
            GetComponent<Text>().text = text;
        }
    }
}