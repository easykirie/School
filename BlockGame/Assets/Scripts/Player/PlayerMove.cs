using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public static float speed = 10f;

    public Transform tr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        tr.position = new Vector3(Mathf.Clamp(tr.position.x, -9.9f, 9.9f) ,Mathf.Clamp(tr.position.y, -11.5f, -9), -0.5f);

        Move();
            
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * speed * Time.deltaTime);
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
