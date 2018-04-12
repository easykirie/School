using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : Character {

    bool isGround;
    float horizontal;

    public float RunSpeed = 1;
    public float JumpForce = 1;

    [Header("Ground Check")]//칼라 빼고 그라운드체크에 필요한것들
    public Color GizmosColor;
    public LayerMask GroundLayer;
    public Vector3 Offset;
    public float Radius = 1;

    public override void OnHurt(int amount)
    {
        base.OnHurt(amount);        
    }

    private void OnDrawGizmos()
    {
        Handles.color = GizmosColor;

        Handles.DrawWireDisc(transform.position + Offset, Vector3.forward, Radius);
    }

    private void Awake()
    {
        GetAnimator = GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        isGround = CheckGround();
        GetAnimator.SetBool("IsGround", isGround);

        Move(horizontal);
    }
    void Move(float h)
    {
        GetAnimator.SetInteger("Run", (int)h);

        if (h == 0)
            return;

        transform.localScale = new Vector3(h, 1, 1);

        transform.Translate(Vector3.right * h * RunSpeed * Time.fixedDeltaTime);
    }

    bool CheckGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position + Offset, Radius, GroundLayer);

        return collider != null ? true : false;

        /*if(collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }*/

    }
}
