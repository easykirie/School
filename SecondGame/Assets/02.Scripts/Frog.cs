using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Frog : Enemy
{

    GroundChecker groundChecker;

    public float JumpForce = 1;


    protected override void FixedUpdate()
    {
        GetAnimator.SetBool("IsGround", groundChecker.IsGround);
        GetAnimator.SetFloat("Velocity.y", Rigid.velocity.y);

        base.FixedUpdate();
    }

    public override void Setup()
    {
        GetAnimator = GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();

        AddState("Idle", new IdleState(this, false));
        AddState("Jump", new JumpState(this, true));

        ChangeState("Idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Character>().OnHurt(10);
    }



}
