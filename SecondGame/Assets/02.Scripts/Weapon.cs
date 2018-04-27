using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    Collider2D collider;

    public int Damage = 10;

    public void SetCollider(bool set)
    {
        collider.enabled = set;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().OnHurt(Damage);
        }
    }

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

}
