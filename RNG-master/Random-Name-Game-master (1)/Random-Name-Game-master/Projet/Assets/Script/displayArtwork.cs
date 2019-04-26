using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BestMasterYi
{
    public class displayArtwork : MonoBehaviour
    {
        public GameObject artwork;



        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                artwork.SetActive(false);
            }
        }
    }
}