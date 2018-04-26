using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Frog
{
    class JumpState : IState
    {
        Frog frog;


        public JumpState(Frog frog, bool useFixedUpdate)
        {
            this.frog = frog;
            UseFixedUpdate = useFixedUpdate;
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

            int dir = Random.Range(0, 2);

            if(dir == 0)
            {
                frog.GetComponent<SpriteRenderer>().flipX = true;
                frog.Rigid.AddForce(new Vector2(0.3f, 1) * frog.JumpForce, ForceMode2D.Impulse);
            }
            else
            {
                frog.GetComponent<SpriteRenderer>().flipX = false;
                frog.Rigid.AddForce(new Vector2(-0.3f, 1) * frog.JumpForce, ForceMode2D.Impulse);
            }
        }

        public void Exit()
        {
            IsRunning = false;
        }

        public void Update()
        {
            

            if(frog.groundChecker.IsGround == true)
            {
                frog.ChangeState("Idle");
            }
        }

        
    }

    class IdleState : IState
    {
        Frog frog;
        float delayTime = 0;


        public IdleState(Frog frog, bool useFixedUpdate)
        {
            this.frog = frog;
            UseFixedUpdate = useFixedUpdate;
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
        }

        public void Exit()
        {
            IsRunning = false;
        }

        public void Update()
        {

            

            if (frog.groundChecker.IsGround == false)
                return;

            if(delayTime >= 1)
            {
                delayTime = 0;
                frog.ChangeState("Jump");
            }
            else
            {
                delayTime += Time.deltaTime;
            }
        }

    }
}