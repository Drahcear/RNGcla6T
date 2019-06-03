using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loot;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lootboxinterditenbelgique()
    {
        int rand = 4;
        if (rand == 4)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
   
    
    
}
