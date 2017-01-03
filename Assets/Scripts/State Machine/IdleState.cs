using UnityEngine;
using System.Collections;

public class IdleState : ISquadState
{
	private readonly StatePatternSquad squad;

	public GameObject player;
	public GameObject enemy;

	//Useful variables here

	public IdleState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;

		player = GameObject.FindGameObjectWithTag ("Squad");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		Look ();


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

		//if (Physics.Raycast (squad.eyes.transform.position, squad.eyes.transform.forward, out hit, squad.sightRange) && hit.collider.CompareTag ("Player")) {
	//	if(Physics.Raycast(squad.transform.position, squad.transform.forward, out hit, squad.sightRange)) {// && hit.collider.CompareTag("Enemy")){
	//		Debug.Log ("TRIGGERED");
	//		squad.followPlayer = hit.transform;
	//		Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
	//		ToCoverState ();
	//	}

		//if (Physics.Raycast (player.transform.position, (enemy.transform.position - player.transform.position), out hit, Mathf.Infinity) && hit.collider.CompareTag ("Enemy")) {
		//if (Physics.Raycast (player.transform.position, player.transform.position, out hit, Mathf.Infinity) && hit.collider.CompareTag("Enemy")) {
		if (Physics.Raycast (player.transform.position, (enemy.transform.position - player.transform.position), out hit, Mathf.Infinity) && hit.collider.CompareTag("Enemy")) {
			Debug.Log ("Enemy spotted");
			squad.followPlayer = hit.transform;
			Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
			Debug.Log ("Switching to cover state");
			ToCoverState ();
		}

		Debug.Log ("No enemies in sight");
	}

}