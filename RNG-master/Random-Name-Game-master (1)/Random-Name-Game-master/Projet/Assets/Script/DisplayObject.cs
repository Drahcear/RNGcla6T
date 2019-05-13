using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BestMasterYi
{

    public class DisplayObject : MonoBehaviour
    {
        public Text ValueTxt;
        public string objet;
        public int nb = 0;
        public int degats;
        public int hp;
        public GameObject Item;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var p in PersistantManagerScript.Instance.artifact)
            {
                if (p == objet)
                    nb += 1;
            }

            switch (PersistantManagerScript.Instance.language)
            {
                case "en":
                    ValueTxt.text = string.Format("x{0}\nattack: {2}\nHp: {1}", nb, hp, degats);
                    break;
                default:
                    ValueTxt.text = string.Format("x{0}\nattaque: {2}\nPv: {1}", nb, hp, degats);
                    break;
            }
        }

        public void SelectItem()
        {
            if (nb > 0)
            {
                PersistantManagerScript.Instance.SelectItem = objet;
            }
        }
    }
}
