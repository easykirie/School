using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public static float speed = 15;

    public float vSpeed = 50;

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

        if (col.gameObject.tag != "Ball")
            return;

        // 입사벡터를 알아본다. (충돌할때 충돌한 물체의 입사 벡터 노말값)
        Vector3 incomingVector = col.relativeVelocity;
        incomingVector = incomingVector.normalized;
        // 충돌한 면의 법선 벡터를 구해낸다.
        Vector3 normalVector = col.contacts[0].normal;
        // 법선 벡터와 입사벡터을 이용하여 반사벡터를 알아낸다.
        Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector); //반사각
        reflectVector = reflectVector.normalized;
        col.rigidbody.velocity = reflectVector * vSpeed; //new Vector3(vSpeed * result, vSpeed, 0.0f);
        /*
        //반사각
        if (col.gameObject.tag == "Ball")
        {
            Vector3 reflect = col.transform.position - tr.position;

            float result = 0.0f;

            if(reflect.x > 0)
            {
                result = -1.0f;
            }
            else if(reflect.x < 0)
            {
                result = 1.0f;
            }
            col.rigidbody.velocity = new Vector3(vSpeed * result, vSpeed, 0.0f);//.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));
        }        */
    }

    
}
