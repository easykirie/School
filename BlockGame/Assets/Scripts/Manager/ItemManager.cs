using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject Item;
    public GameObject Cam;
    static float CamRotate =45;

    public void Awake()
    {
        
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void ThisTag()
    {
        if(Item.tag == "H_Item")
        {
            BallController.reviveCount += 1;
        }
        else if(Item.tag == "D_Item")
        {
            Cam.transform.rotation = Quaternion.Euler(0, 0, CamRotate);
            CamRotate += 45;
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
