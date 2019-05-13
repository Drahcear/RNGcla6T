using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace BestMasterYi
{
    public class SummonScript : MonoBehaviour
    {
        public string type;
        public int cost;
        public List<GameObject> L; 
        public List<string> Mcharacter;
        public List<string> Rcharacter;
        public List<string> Ccharacter;
        public string[,] Object;
        
        
        private int n;
        public int M;
        public int R;

        public void Pull()
        {
            if (PersistantManagerScript.Instance.money >= cost)
            {
                PersistantManagerScript.Instance.money -= cost;
                string s = "";
                n = Random.Range(0, 101);
                if (n <= M)
                {
                    s = Mcharacter[Random.Range(0, Mcharacter.Count)];
                }
                else if (n <= M + R)
                {
                    s = Rcharacter[Random.Range(0, Rcharacter.Count)];
                }
                else
                {
                    s = Ccharacter[Random.Range(0, Ccharacter.Count)];
                }
                foreach (var o in L)
                {
                    if(o.name == s+"_artwork")
                        o.SetActive(true);
                }

                if (type == "Hero")
                {
                    PersistantManagerScript.Instance.summoned.Add(s);
                }
                else
                    PersistantManagerScript.Instance.artifact.Add(s);
            }
        }

        
        
        
    }
}
