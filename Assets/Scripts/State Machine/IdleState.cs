using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class IdleState : ISquadState
{
	private readonly StatePatternSquad squad;

	public GameObject player;
	public GameObject enemy;

	NavMeshAgent agent;

	public float speed = 3 * Time.deltaTime;

	public float distance;
	public float dist = 10.0f;


	public float minRange = 2.0f;
	public float maxRange = 30.0f;
	public float separation;
	public Vector3 DistancE;
	public Vector3 targetDir;
	float minOne = -1;
	Vector3 newDir;

	//Useful variables here

	public IdleState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;

		agent.GetComponent<NavMeshAgent> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		Look ();
		follow ();
	}

	public void ToIdleState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToCoverState()
	{
		squad.currentState = squad.coverState;
	}

	public void ToAttackState()
	{
		squad.currentState = squad.attackState;
	}



	public void OrderAttackState()
	{
		squad.currentState = squad.orderAttackState;
	}

	public void OrderDefendState()
	{
		squad.currentState = squad.orderDefendState;
	}

	public void OrderMoveState()
	{
		squad.currentState = squad.orderMoveState;
	}

	public void OrderDestructState()
	{
		squad.currentState = squad.orderDestructState;
	}



	private void Look()
	{
		RaycastHit hit;

		if (Physics.Raycast (squad.transform.position, (enemy.transform.position - squad.transform.position), out hit, Mathf.Infinity) && hit.collider.CompareTag ("Enemy")) {
			Debug.Log ("Enemy spotted");
			squad.followPlayer = hit.transform;
			Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
			Debug.Log ("Switching to cover state");
			ToCoverState ();
		}

		follow ();

		Debug.Log ("No enemies in sight");
	}


	private void follow()
	{

		targetDir = player.transform.position - squad.transform.position;
		DistancE.x = player.transform.position.x - squad.transform.position.x;
		DistancE.z = player.transform.position.z - squad.transform.position.z;

		if(DistancE.x <=  0)
			DistancE.x = DistancE.x * minOne;

		if(DistancE.z <=  0)
			DistancE.z = DistancE.z * minOne;

		//PYTHAGORAS FOR SEPARATION BETWEEN PLAYER AND SQUAD
		separation = (DistancE.x * DistancE.x) + (DistancE.z * DistancE.z);
		separation = Mathf.Sqrt (separation);


		if ((separation >= minRange) && (separation <= maxRange))
		{
			newDir = Vector3.RotateTowards (squad.transform.forward, targetDir, speed, 0.0f);
			Debug.DrawRay (squad.transform.position, newDir, Color.red);
			squad.transform.rotation = Quaternion.LookRotation (newDir);
			agent.SetDestination (player.transform.position);
		}
	}
}