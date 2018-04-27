using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pickup(collision);
            Destroy(gameObject);
        }

    }

    protected virtual void Pickup(Collider2D collision)
    {

    }
    

}
