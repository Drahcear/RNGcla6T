using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace BestMasterYi
{
    public class SummonScript : MonoBehaviour
    {
        private int Money;

        public List<GameObject> L; 
        public List<string> Mcharacter;
        public List<string> Rcharacter;
        public List<string> Ccharacter;

        private int n;
        public int M;
        public int R;

        public void Pull()
        {
            string s = "";
            n = Random.Range(0, 101);
            if (n <= M)
            {
                s = Mcharacter[Random.Range(0, Mcharacter.Count)];
                PersistantManagerScript.Instance.summoned.Add(s);
            }
            else if (n <= M + R)
            {
                s = Rcharacter[Random.Range(0, Rcharacter.Count)];
                PersistantManagerScript.Instance.summoned.Add(s);
            }
            else
            {
                s = Ccharacter[Random.Range(0, Ccharacter.Count)];
                PersistantManagerScript.Instance.summoned.Add(s);
            }

            foreach (var o in L)
            {
                if(o.name == s+"_artwork")
                    o.SetActive(true);
            }
        }
    }
}
