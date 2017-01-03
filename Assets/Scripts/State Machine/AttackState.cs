using UnityEngine;
using System.Collections;

public class AttackState : ISquadState
{
	private readonly StatePatternSquad squad;
	//Useful variables here

	public AttackState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;
	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		Look ();
	}

	public void ToIdleState()
	{
		squad.currentState = squad.idleState;
	}

	public void ToCoverState()
	{
		squad.currentState = squad.coverState;
	}

	public void ToAttackState()
	{
		Debug.Log ("Can't transition to same state");
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
		if(Physics.Raycast(squad.transform.position, squad.transform.forward, out hit, squad.sightRange) && hit.collider.CompareTag("Enemy")){
			Debug.Log ("Enemy spotted");
			squad.followPlayer = hit.transform;
			Debug.DrawRay (squad.transform.position, squad.followPlayer.position, Color.red);
			Debug.Log ("switching to cover state");
			ToCoverState ();
		}
		Debug.Log ("No enemies in sight");
	}

}