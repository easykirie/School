using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text text;

    public Transform B_Points;

    public GameObject Ball;

    public GameObject BSP;

    public GameObject pause;

    public GameObject Over;

    public bool IsStart;

    public GameObject Debuff;

    public GameObject Health;

    Rigidbody rigid;

    float BallSpeed = 1000;


    GameObject ball;
    

    


    // Use this for initialization
    void Start () {
        //ball = GameObject.FindGameObjectWithTag("Ball");
        text.text = "목숨 : " + BallController.reviveCount;
        IsStart = true;
        rigid = Ball.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "목숨 : " + BallController.reviveCount;

        if (Input.GetKeyDown(KeyCode.D))
            Instantiate(Debuff, Debuff.transform.position, Debuff.transform.rotation);
        if (Input.GetKeyDown(KeyCode.H))
            Instantiate(Health, Health.transform.position, Health.transform.rotation);

        if (B_Points.childCount == 0 && IsStart == true)
        {
            IsStart = false;
            pause.gameObject.SetActive(true);
            PauseManager.IsOver = true;
            Time.timeScale = 0;
        }

        if(B_Points.childCount > 0 && BallController.reviveCount <= 0 && IsStart == true)
        {
            IsStart = false;
            Over.gameObject.SetActive(true);
            OverManager.IsEnd = true;
            Time.timeScale = 0;
        }

        if(ItemManager.IsCreate == true)
        {
            GameObject obj = Instantiate(Ball, BSP.transform.position, Quaternion.identity);
            obj.transform.SetParent(BSP.transform);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.up * BallSpeed);
            obj.layer = 0;
            obj.transform.SetParent(null);
            ItemManager.IsCreate = false;
        }
    }
}
