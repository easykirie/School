using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject Item;

    public void Awake()
    {
        
    }

    public void ThisTag()
    {
        if(Item.tag == "H_Item")
        {
            BallController.reviveCount++;
        }
        if(Item.tag == "D_Item")
        {
            if (PlayerMove.speed <= 2)
                return;
            PlayerMove.speed -= 1;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            ThisTag();
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
