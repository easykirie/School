using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text text;

    public Transform B_Points;

    public GameObject pause;

    public bool IsStart;

    public GameObject Debuff;

    


    // Use this for initialization
    void Start () {        
        text.text = "목숨 : " + BallController.reviveCount;
        IsStart = true;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "목숨 : " + BallController.reviveCount;

        if (Input.GetKeyDown(KeyCode.D))
            Instantiate(Debuff, Debuff.transform.position, Debuff.transform.rotation);

        if (B_Points.childCount == 0 && IsStart == true)
        {
            IsStart = false;
            pause.gameObject.SetActive(true);
            PauseManager.IsOver = true;
            Time.timeScale = 0;
        }

    }
}
