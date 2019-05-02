using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            transform.position = new Vector2(transform.position.x,other.transform.position.y-200);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            transform.position = new Vector2(transform.position.x,other.transform.position.y-200);
        }
    
    }
}
