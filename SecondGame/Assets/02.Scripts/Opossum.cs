using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    public float MoveSpeed = 1;

    public override void Setup()
    {
        AddState("Move", new MoveState(this, true));

        ChangeState("Move");
    }

    

    class MoveState : IState
    {
        Opossum opossum;
        float delayTime;
        int direction = 1;

        public MoveState(Opossum opossum, bool useFixedupdate)
        {
            this.opossum = opossum;
            this.UseFixedUpdate = useFixedupdate;
        }

        public bool IsRunning
        {
            get;
            private set;            
        }

        public bool UseFixedUpdate
        {
            get;
            private set;
        }

        public void Enter()
        {
            IsRunning = true;
            opossum.GetComponent<SpriteRenderer>().flipX = direction > 0 ? true : false;
        }

        public void Exit()
        {
            IsRunning = false;
        }

        public void Update()
        {
            if(delayTime >= 1)
            {
                delayTime = 0;
                direction *= -1;
                opossum.GetComponent<SpriteRenderer>().flipX = direction > 0 ? true : false;
            }
            else
            {
                delayTime += Time.fixedDeltaTime;
            }

            opossum.transform.Translate(Vector3.right * opossum.MoveSpeed *  direction * Time.fixedDeltaTime);
        }
    }
}
