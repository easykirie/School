using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text ScoreText;
	public float num1;


	// Use this for initialization
	void Start () {		
		num1 = 1000;
		ScoreText.text = string.Format ("점수 : {0}", num1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ScoreResult(Result result)
	{
		if (result.Strike != 3) 
		{
			num1 = num1 - 100;
			ScoreText.text = string.Format("점수 : {0}", num1);
		}
	}
}
