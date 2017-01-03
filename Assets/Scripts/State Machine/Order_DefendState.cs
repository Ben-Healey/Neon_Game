using UnityEngine;
using System.Collections;


public class Order_DefendState : ISquadState
{
	private readonly StatePatternSquad squad;
	//Useful variables here

	public Order_DefendState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;
	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		//Look ();
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
		squad.currentState = squad.attackState;
	}



	public void OrderAttackState()
	{
		squad.currentState = squad.orderAttackState;
	}

	public void OrderDefendState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void OrderMoveState()
	{
		squad.currentState = squad.orderMoveState;
	}

	public void OrderDestructState()
	{
		squad.currentState = squad.orderDestructState;
	}
}