using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    float _horizontal = 0;
    float _vertical = 0;

    float _speed = 0;

    public float MoveSpeed = 1;
    public float RunSpeed = 2;

    void Awake()
    {
        _speed = MoveSpeed;
    }

    public void SetRun(bool isRun)
    {
        if (isRun)
            _speed = RunSpeed;
        else
            _speed = MoveSpeed;
    }

    public void SetDirection(float h, float v)
    {
        _horizontal = h;
        _vertical = v;
    }

    void FixedUpdate()
    {
        transform.Translate((Vector3.right * _horizontal + Vector3.forward * _vertical) * Time.fixedDeltaTime * _speed);
    }

}
