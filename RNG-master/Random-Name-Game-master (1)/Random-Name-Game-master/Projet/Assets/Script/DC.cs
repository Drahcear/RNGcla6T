using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disco()
    {
                
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "player")
                    disco();
            }
}
