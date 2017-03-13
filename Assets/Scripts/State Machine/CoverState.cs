﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class CoverState : ISquadState
{

	public List<GameObject> coverList = new List<GameObject> ();
	public List<GameObject> validCover = new List<GameObject> ();


	private readonly StatePatternSquad squad;

	private Vector3 Direction;

	public GameObject player;
	public GameObject enemy;
	public GameObject[] cover;

	//Useful variables here

	public CoverState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		cover = GameObject.FindGameObjectsWithTag ("Cover");
	}
		
	public void UpdateState() 
	{
		//Call fucntions you want to constantly repeat here
		//look();

		for (int i = 0; i < coverList.Count; i++)
		{

			if (coverList [i].GetComponent<CoverEnabler> ().CheckValid ())
			{
				if(!validCover.Contains(coverList[i]))
					validCover.Add(coverList[i]);
			}

			if (validCover.Contains (coverList [i]))
			{
				if (!coverList [i].GetComponent<CoverEnabler> ().CheckValid ())
				{
					validCover.Remove(coverList[i]);
				}
			}
		}
		moveToCover();
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


	void OnTriggerEnter (Collider _collision)
	{
		if (_collision.gameObject.CompareTag ("Cover"))
			coverList.Add (_collision.gameObject);
	}

	void OnTriggerExit (Collider _collision)
	{
		if (_collision.gameObject.CompareTag ("Cover"))
		{
			if(validCover.Contains(_collision.gameObject))
				validCover.Remove(_collision.gameObject);

			coverList.Remove (_collision.gameObject);
		}
	}


	private void moveToCover()
	{
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;

		foreach (GameObject cover in validCover)
		{
			Vector3 directionToTarget = cover.transform.position - squad.transform.position;
			float distSqrToTgt = directionToTarget.sqrMagnitude;

			if (distSqrToTgt < closestDistanceSqr)
			{
				closestDistanceSqr = distSqrToTgt;
				bestTarget = cover.transform;
			}
		}

		if (bestTarget == null)
		{
			Debug.Log ("Best target = null");
			Vector3 goForward = squad.transform.position + Vector3.forward;
			bestTarget = player.transform;
		}
		Debug.Log ("Moving to cover");
		squad.agent.SetDestination (bestTarget.position);
		//return bestTarget.position;
	}

}


	//STUFF BELOW WORKS, BUT WITH A MASSIVE OVERFLOW ISSUE
	/*
	private void Look()
	{
		RaycastHit hit;

		Direction = enemy.transform.position - player.transform.position;

		if (Physics.Raycast (player.transform.position, Direction, out hit, 50) && hit.collider.CompareTag ("Enemy"))
		{
			squad.followPlayer = hit.transform;
			Debug.DrawRay (squad.transform.position, hit.transform.position, Color.red);
			moveToCover ();
		}
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

				Vector3 targetDir = Cover.transform.position - enemy.transform.position;
				float targetDist = targetDir.sqrMagnitude;


				Vector3 playerDir = Cover.transform.position - player.transform.position;
				float playerDist = playerDir.sqrMagnitude;

				if (targetDist < nearest) {
					nearest = targetDist;
					bestCover = Cover.transform;
				}
		}

		squad.agent.SetDestination (bestCover.transform.position);

		squad.transform.LookAt (bestCover.transform.position);

		Look ();
	}*/
