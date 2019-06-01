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
        public string FR;
        public string EN;
        public int nb;
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
                    ValueTxt.text = string.Format("  {3}\n  x{0}\n\n\n\n\n\n  attack: {2}\n  Hp: {1}", nb, hp, degats,EN);
                    break;
                default:
                    ValueTxt.text = string.Format("  {3}\n  x{0}\n\n\n\n\n\n  attaque: {2}\n  Pv: {1}", nb, hp, degats,FR);
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
