using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    

    public Transform Target;

    public float Speed = 1;
    public float rotateSpeed = 2;

    public float Distance = 10;

    public Vector3 Offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Translate((Vector3.right * h + Vector3.up * v) * Speed * Time.fixedDeltaTime);
        transform.LookAt(Target.position);




    }
}
