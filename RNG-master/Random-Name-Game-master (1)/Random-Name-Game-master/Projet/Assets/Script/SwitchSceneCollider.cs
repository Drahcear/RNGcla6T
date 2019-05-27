using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BestMasterYi
{

    public class SwitchSceneCollider : MonoBehaviour
    {
        public string Scene;

        private void OnTriggerEnter2D(Collider2D other)
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
