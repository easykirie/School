using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Player : Character {

    bool isGround;
    float horizontal;

    public float RunSpeed = 1;
    public float JumpForce = 1;

    public GameObject GameOverUI;

    public int WeaponIndex = -1;    
    public List<Weapon> ListofWeapon;

    Weapon weapon = null;

    bool IsAttack = false;

    GroundChecker groundChecker;

    //[header("ground check")]//칼라 빼고 그라운드체크에 필요한것들
    //public color gizmoscolor;
    //public layermask groundlayer;
    //public vector3 offset;
    //public float radius = 1;

    public void SetWeapon(int index)
    {
        WeaponIndex = index;

        if (weapon != null)
            weapon.gameObject.SetActive(false);

        weapon = ListofWeapon[WeaponIndex];
        weapon.gameObject.SetActive(true);
    }

    void Dead()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }

    public override void OnHurt(int amount)
    {
        GetAnimator.SetTrigger("Hurt");
        base.OnHurt(amount);
        OffAttack();

        if(Health <= 0)
        {
            Dead();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //private void OnDrawGizmos()
    //{
    //    Handles.color = GizmosColor;

    //    Handles.DrawWireDisc(transform.position + Offset, Vector3.forward, Radius);
    //}

    private void Awake()
    {
        GetAnimator = GetComponent<Animator>();
        Rigid = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Jump();

        if(weapon != null)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
            }
        }
    }

    public void OnAttack()
    {
        if (weapon == null)
            return;

        IsAttack = true;

        weapon.SetCollider(true);
    }

    public void OffAttack()
    {
        if (weapon == null) 
           return;

        IsAttack = false;

        weapon.SetCollider(false);
    }

    void Attack()
    {
        if (IsAttack == true)
            return;

        GetAnimator.SetTrigger("Attack");
    }

    private void FixedUpdate()
    {
        //isGround = CheckGround();
        GetAnimator.SetBool("IsGround", groundChecker.IsGround);

        Move(horizontal);

        float vY = Rigid.velocity.y;

        GetAnimator.SetFloat("VelocityY", vY);
    }
    void Move(float h)
    {
        GetAnimator.SetInteger("Run", (int)h);

        if (h == 0)
            return;

        transform.localScale = new Vector3(h, 1, 1);

        transform.Translate(Vector3.right * h * RunSpeed * Time.fixedDeltaTime);
    }

    //bool CheckGround()
    //{
    //    Collider2D collider = Physics2D.OverlapCircle(transform.position + Offset, Radius, GroundLayer);

    //    return collider != null ? true : false;

    //    /*if(collider != null)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }*/

    //}

    void Jump()
    {
        if (!groundChecker.IsGround) //isGround == false;
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigid.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
