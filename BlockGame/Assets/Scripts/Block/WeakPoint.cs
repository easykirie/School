using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

    public bool WeakPointHit = false;

    void Awake()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            WeakPointHit = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
