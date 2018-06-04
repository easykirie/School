using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Super.FSM
{

	public class FSM : MonoBehaviour
	{

		protected NavMeshAgent agent;

		public int Health = 10;
		int currentHealth = 0;

		public virtual void TakeDamage(int damage)
		{
			currentHealth -= damage;
		}

		protected virtual void Awake()
		{
			agent = GetComponent<NavMeshAgent>();

			currentHealth = Health;
		}

		protected void SetMovePoint(Vector3 point)
		{
			agent.SetDestination(point);
		}

		protected virtual void Patrol()
		{

		}

		protected void StartMove()
		{
			agent.isStopped = false;
		}
		protected void StopMove()
		{
			agent.isStopped = true;
		}

		protected virtual void Dead()
		{

		}

	}

}