using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath : MonoBehaviour {

    //공 삭제만 하는 스크립트임.

   

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "WallD")
        {
            ScoreManager.score -= 50;
            BallController.reviveCount = BallController.reviveCount - 1;
            Debug.Log(BallController.reviveCount + ", " + col.gameObject.name);
            Destroy(gameObject);
            PlayerMove.speed = 10;

            
            
        }
    }
}
