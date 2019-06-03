using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;

public class ZeniMoney : MonoBehaviour
{
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            //machinpersistantmanager.money += money;
            Destroy(gameObject);
        }
    }
}
