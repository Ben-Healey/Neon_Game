using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class IdleState : ISquadState
{
	private readonly StatePatternSquad squad;

	public GameObject player;
	public GameObject enemy;
	public GameObject[] othSquad;

	//NavMeshAgent agent = GetComponent<NavMeshAgent>();

	public float speed = 3 * Time.deltaTime;

	public float distance;
	public float dist = 10.0f;


	public float minRange = 3.0f;
	public float maxRange = 30.0f;
	public float separation;
	public Vector3 DistancE;

	public float squadSep;
	public Vector3 squadDist;

	public Vector3 targetDir;
	float minOne = -1;
	Vector3 newDir;
	private float vSpeed = 0;

	//Useful variables here

	public IdleState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;

		//agent = GetComponent<NavMeshAgent> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		othSquad = GameObject.FindGameObjectsWithTag ("Squad");
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
			//Debug.Log ("Enemy spotted");
			squad.followPlayer = hit.transform;
			Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
			//Debug.Log ("Switching to cover state");
			ToCoverState ();
		}

		follow ();

		//Debug.Log ("No enemies in sight");
	}


	private void follow()
	{

		//squad.myAnimator.SetFloat ("VSpeed", Input.GetAxis ("Vertical"));
		for (int i = 0; i < othSquad.Length; i++) {

			targetDir = player.transform.position - squad.transform.position;
			DistancE.x = player.transform.position.x - squad.transform.position.x;
			DistancE.z = player.transform.position.z - squad.transform.position.z;

			if (DistancE.x <= 0)
				DistancE.x = DistancE.x * minOne;

			if (DistancE.z <= 0)
				DistancE.z = DistancE.z * minOne;

			//PYTHAGORAS FOR SEPARATION BETWEEN PLAYER AND SQUAD
			separation = (DistancE.x * DistancE.x) + (DistancE.z * DistancE.z);
			separation = Mathf.Sqrt (separation);



			//PYTHAGORAS FOR SEPARATION BETWEEN SQUAD AND SQUAD (HOPEFULLY)
			squadDist.x = squad.transform.position.x - othSquad [i].transform.position.x;
			squadDist.z = squad.transform.position.z - othSquad [i].transform.position.z;

			if (squadDist.x <= 0)
				squadDist.x = squadDist.x * minOne;

			if (squadDist.z <= 0)
				squadDist.z = squadDist.z * minOne;

			squadSep = (squadDist.x * squadDist.x) + (squadDist.z * squadDist.z);
			squadSep = Mathf.Sqrt (squadSep);



			if (squadSep <= minRange)
			{
				//squad.agent.transform.position.y += 10;
			}




			if ((separation >= minRange) && (separation <= maxRange))
			{
				newDir = Vector3.RotateTowards (squad.transform.forward, targetDir, speed, 0.0f);
				Debug.DrawRay (squad.transform.position, newDir, Color.red);
				squad.transform.rotation = Quaternion.LookRotation (newDir);
				squad.agent.SetDestination (player.transform.position);

				squad.myAnimator.SetFloat ("VSpeed", (vSpeed += 0.1f));
			} else
			{
				squad.myAnimator.SetFloat ("VSpeed", (vSpeed = 0.0f));
            }
		}
	}
}