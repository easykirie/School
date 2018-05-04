using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

    public Transform MainCamera;

    public float CameraDistance;

    public float SensitivityX = 4;
    public float SensitivityY = 4;
    public float ScrollSensitivity = 2;

    public float OrbitDampening = 10;
    public float ScrollDampening = 6;

    Vector3 _localRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        if(h != 0 || v != 0)
        {
            _localRotation.x += h * SensitivityX;
            _localRotation.y += v * SensitivityY;

            if (_localRotation.y < 0)
                _localRotation.y = 0;
            else if (_localRotation.y > 90)
                _localRotation.y = 90;
                       
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll != 0)
        {
            float scrollAmount = scroll * ScrollSensitivity;

            scrollAmount *= (CameraDistance * 0.3f);

            CameraDistance -= scrollAmount;

            CameraDistance = Mathf.Clamp(CameraDistance, 1.5f, 10);
        }


        Quaternion QT = Quaternion.Euler(_localRotation.y, _localRotation.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * OrbitDampening);

        if(MainCamera.localPosition.z != CameraDistance * -1)
        {
            MainCamera.localPosition = new Vector3(0, 0, Mathf.Lerp(MainCamera.localPosition.z, -CameraDistance, Time.deltaTime * ScrollDampening));
        }
    }
}
