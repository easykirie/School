using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject Ball;
    public GameObject BSP;
    public GameObject Item;
    public GameObject Cam;
    static float CamRotate =45;
    public float BallSpeed = 1000;
    Rigidbody rigid;
    public static bool IsCreate = false;

    public void Awake()
    {
        rigid = Ball.GetComponent<Rigidbody>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        BSP = GameObject.FindGameObjectWithTag("BSP");
    }

    public void ThisTag()
    {
        if(Item.tag == "H_Item")
        {
            BallController.reviveCount += 1;
        }
        else if(Item.tag == "D_Item")
        {
            float D_Num = Random.Range(0, 2);

            if(D_Num == 0)
            {
                Cam.transform.rotation = Quaternion.Euler(0, 0, CamRotate);
                CamRotate += 45;
            }
            else if(D_Num == 1)
            {
                IsCreate = true;                                
            }
                
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            ThisTag();
            Destroy(gameObject, 0.1f);
        }
    }


    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
        
	}
}
