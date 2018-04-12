using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text text;

    

    // Use this for initialization
    void Start () {
        text.text = "목숨 : " + BallController.reviveCount;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "목숨 : " + BallController.reviveCount;
    }
}
