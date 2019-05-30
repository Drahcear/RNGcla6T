using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{



    public class Boss2IAShot : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.GetComponent<Rigidbody2D>().velocity =
                new Vector2(-5, transform.GetComponent<Rigidbody2D>().position.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((other.gameObject.tag == "player" || other.gameObject.tag == "Melee" ||
                 other.gameObject.tag == "Bullet") &&
                other.gameObject.tag != "Méchantshot")
            {
                Destroy(gameObject);
            }
        }
    }
}
