using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public GameObject block;    

	// Use this for initialization
	void Start () {
        
	}	

	// Update is called once per frame
	void Update () {
		
	}
    

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ball")
        {
            if (block.tag == "Block")
            {
                ScoreManager.score += 10;
                Destroy(gameObject);
            }
            else if(block.tag == "BlockW")
            {
                ScoreManager.score += 20;
                Destroy(gameObject);
            }
        }
    }
}
