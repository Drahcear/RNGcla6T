using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BestMasterYi
{
    public class DisplayStats : MonoBehaviour
    {
        public Text ValueTxt;
        public string perso;
        private int lvl = 0;
        public int degats;
        public int hp;
        private List<int> modif;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var p in PersistantManagerScript.Instance.summoned)
            {
                if (p == perso)
                    lvl += 1;
            }

            switch (perso)
            {
                case "Tank":
                    modif = PersistantManagerScript.Instance.TankModif;
                    break;
                case "Chevalier":
                    modif = PersistantManagerScript.Instance.ChevalierModif;
                    break;
                case "Demon":
                    modif = PersistantManagerScript.Instance.DemonModif;
                    break;
                default:
                    modif = PersistantManagerScript.Instance.HeroModif;
                    break;
            }

            switch (PersistantManagerScript.Instance.language)
            {
                case "en":
                    ValueTxt.text = string.Format("\nLevel {0}\n\nHp: {1}+{2}\n\nAttack: {3}+{4}\n\n", lvl, hp, modif[0],
                        degats, modif[1]);
                    break;
                default:
                    ValueTxt.text = string.Format("\nNiveau {0}\n\nPv: {1}+{2}\n\nAttaque: {3}+{4}\n\n", lvl, hp,
                        modif[0], degats, modif[1]);
                    break;
            }
        }

        public void EquipItem()
        {
            if (PersistantManagerScript.Instance.SelectItem != "")
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("Item"))
                {
                    if (item.name == PersistantManagerScript.Instance.SelectItem)
                    {
                        DisplayObject objet = item.GetComponent<DisplayObject>();
                        if (objet.nb > 0)
                        {
                            modif[0] += objet.hp;
                            modif[1] += objet.degats;
                            PersistantManagerScript.Instance.artifact.Remove(item.GetComponent<DisplayObject>().objet);
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        }
                    }
                }
                
            }
        }
        
    }
}
