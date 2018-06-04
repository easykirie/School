using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Super.FSM
{

	public class FSMDino : FSM
	{
		public enum DinoState
		{
			Idle,
			Patrol,
			Attack,
			Dead,
		}

		public DinoState State;

		public Transform Target;
		public float IdleTime = 1;

		public float AttackRange = 1;
		public float SenserRange = 1;

		public List<Transform> PatrolPoint;

		[Header("Debug")]
		public Color AttackRangeColor;
		public Color SneserRangeColor;

		float currentIdleTime = 0;
		int patrolIndex = 0;
		Animator anim;

		protected override void Patrol()
		{
			if (Vector3.Distance(transform.position, PatrolPoint[patrolIndex].position) <= 0.1f)
			{
				Debug.Log("O");
				State = DinoState.Idle;
				anim.SetBool("IsRun", false);
				return;
			}
			else
			{

				Debug.Log("NO");
			}
		}

		protected override void Awake()
		{
			base.Awake();
			anim = GetComponent<Animator>();
		}

		private void Update()
		{
			if(State == DinoState.Idle)
			{
				if(currentIdleTime >= IdleTime)
				{
					currentIdleTime = 0;
					State = DinoState.Patrol;
					patrolIndex = Random.Range(0, PatrolPoint.Count);
					anim.SetBool("IsRun", true);
					SetMovePoint(PatrolPoint[patrolIndex].position);
				}
				else
				{
					currentIdleTime += Time.deltaTime;
				}
			}
			else if(State == DinoState.Patrol)
			{
				Patrol();

			}
		}

		void OnDrawGizmos()
		{
			
		}
	}

}