using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    static public int score;

    static public Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        text.text = "Score : " + score;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {        
        if (score < 0)
            score = 0;
        text.text = "Score : " + score;
    }
}
