using UnityEngine;
using System.Collections;


public class Order_MoveState : ISquadState
{
	private readonly StatePatternSquad squad;
	//Useful variables here

	public GameObject player;

	public Order_MoveState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		//Look ();
		MoveTO();
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
		squad.currentState = squad.orderDefendState;
	}

	public void OrderMoveState()
	{
		squad.currentState = squad.orderMoveState;
	}

	public void OrderDestructState()
	{
		Debug.Log ("Can't transition to same state");
	}




	public void MoveTO()
	{
		Vector3 ray;
		RaycastHit hit;

		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
			squad.transform.LookAt (hit.point);
			squad.transform.Translate (hit.point);
		}


	}


}