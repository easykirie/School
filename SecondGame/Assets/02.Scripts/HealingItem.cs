using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : PickUpItem {

    public int HealValue = 10;

	protected override void Pickup(Collider2D collision)
    {
        collision.GetComponent<Player>().Health += HealValue;
    }
}
