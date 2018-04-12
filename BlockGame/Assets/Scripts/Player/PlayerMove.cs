using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 6f;

    public Transform tr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //반사각
        if(col.gameObject.tag == "Ball")
        {
            Vector3 reflect = col.transform.position - tr.position;

            float result = 0.0f;

            if(reflect.x > 0)
            {
                result = 1.0f;
            }
            else if(reflect.x < 0)
            {
                result = -1.0f;
            }
            col.rigidbody.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));
        }
    }
}
