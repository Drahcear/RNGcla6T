using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyNamespace
{
    public class HPBAR : MonoBehaviour
    {
        private Transform bar;
        private void Start()
        {
            
            bar = transform.Find("BAR");          
            
        }

        // Update is called once per frame        
        public void SetSize(float sizeNormalized)
        {
            bar.localScale = new Vector3(sizeNormalized, 1f);
        }
    }
}