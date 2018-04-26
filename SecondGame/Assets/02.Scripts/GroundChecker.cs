using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundChecker : MonoBehaviour {


    [Header("Ground Check")]//칼라 빼고 그라운드체크에 필요한것들
    public Color GizmosColor = Color.red;
    public LayerMask GroundLayer;
    public Vector3 Offset;
    public float Radius = 1;

    public bool IsGround
    {
        get;
        private set;
    }

    private void FixedUpdate()
    {
        IsGround = CheckGround();
    }


    private void OnDrawGizmos()
    {
        Handles.color = GizmosColor;

        Handles.DrawWireDisc(transform.position + Offset, Vector3.forward, Radius);
    }

    bool CheckGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position + Offset, Radius, GroundLayer);

        return collider != null ? true : false;
    }

}
