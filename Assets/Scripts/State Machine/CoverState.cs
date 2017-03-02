using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class CoverState : ISquadState
{
	private readonly StatePatternSquad squad;

	public GameObject player;
	public GameObject enemy;
	//public GameObject cover;

	//NavMeshAgent agent;

	//agent.GetComponent<NavMeshAgent> ();

	public GameObject[] cover;

	//Useful variables here

	public CoverState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;

		//agent.GetComponent<NavMeshAgent> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		cover = GameObject.FindGameObjectsWithTag ("Cover");
	}
		
	public void UpdateState() 
	{
		//Call fucntions you want to constantly repeat here
		moveToCover ();
	}

	public void ToIdleState()
	{
		squad.currentState = squad.idleState;
	}

	public void ToCoverState()
	{
		Debug.Log ("Can't transition to same state");
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

		//if (Physics.Raycast (squad.eyes.transform.position, squad.eyes.transform.forward, out hit, squad.sightRange) && hit.collider.CompareTag ("Player"))
		if (Physics.Raycast (player.transform.position, (enemy.transform.position - player.transform.position), out hit, Mathf.Infinity) && hit.collider.CompareTag ("Enemy")) {
			Debug.Log ("Enemy spotted");
			squad.followPlayer = hit.transform;
			//Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
			Debug.DrawRay (squad.transform.position, hit.transform.position, Color.red);
			Debug.Log ("Moving to cover");
			moveToCover ();
		}

		Debug.Log ("In cover");

		Debug.Log ("No enemies in sight");

		Debug.Log ("Switching to Idle state");

		ToIdleState ();
	}

	private void moveToCover ()
	{
		RaycastHit hit;
		float step;
		step = squad.speed * Time.deltaTime;



		Transform bestCover = null;
		float nearest = Mathf.Infinity;

		foreach (GameObject Cover in cover) {

			bool isValid = false;

			if (Physics.Raycast (Cover.transform.position, (Cover.transform.position - player.transform.position), out hit, Mathf.Infinity)) {
				isValid = true;
			}

			if (isValid == true) {


				Vector3 targetDir = Cover.transform.position - enemy.transform.position;
				float targetDist = targetDir.sqrMagnitude;


				Vector3 playerDir = Cover.transform.position - player.transform.position;
				float playerDist = playerDir.sqrMagnitude;

				if (targetDist < nearest) {
					nearest = targetDist;
					bestCover = Cover.transform;
					Debug.DrawRay (Cover.transform.position, (player.transform.position - Cover.transform.position), Color.green);
				}
			}
		}


		squad.transform.position = Vector3.MoveTowards (squad.transform.position, bestCover.transform.position, step);

		//agent.SetDestination (bestCover.transform.position);

		squad.transform.LookAt (bestCover.transform.position);

		Look ();
	}
}