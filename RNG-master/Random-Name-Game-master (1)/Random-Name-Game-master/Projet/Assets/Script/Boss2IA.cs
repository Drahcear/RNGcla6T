using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace BestMasterYi
{



    public class Boss2IA : MonoBehaviour
    {
        public GameObject Shot1;

        public GameObject Shot2;
        public GameObject Shot3;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Attack1()
        {
            Vector3 pos1 = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            var shot1 = Instantiate(Shot1, pos1, Quaternion.identity);                      
        }

        public void Attack2()
        {
            Vector3 pos1 = new Vector3(transform.position.x - 1, transform.position.y+1.5f, transform.position.z);
            var shot2 = Instantiate(Shot2, pos1, Quaternion.identity);
        }

        public void Attack3()
        {
            Vector3 pos1 = new Vector3(transform.position.x - 1, transform.position.y+6f, transform.position.z);
            var shot2 = Instantiate(Shot3, pos1, Quaternion.identity); 
        }
    }
}
