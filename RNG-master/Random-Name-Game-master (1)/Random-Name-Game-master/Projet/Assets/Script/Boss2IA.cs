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
            Vector3 pos2 = new Vector3(transform.position.x - 1, transform.position.y - 0.4f, transform.position.z);
            var shot2 = Instantiate(Shot1, pos1, Quaternion.identity);
            Vector3 pos3 = new Vector3(transform.position.x - 1, transform.position.y - 0.8f, transform.position.z);
            var shot3 = Instantiate(Shot1, pos1, Quaternion.identity);
            


        }
    }
}
