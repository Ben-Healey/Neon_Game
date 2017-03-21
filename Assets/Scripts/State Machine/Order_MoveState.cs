using UnityEngine;
using System.Collections;


public class Order_MoveState : ISquadState
{
	private readonly StatePatternSquad squad;
	//Useful variables here

	public GameObject player;
	private Vector3 Destination;
	private RaycastHit hit;

	public Order_MoveState (StatePatternSquad statePatternSquad)
	{
		squad = statePatternSquad;
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public void UpdateState()
	{
		//Call fucntions you want to constantly repeat here
		//Look ();

		Debug.Log ("Order Move");
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
		Debug.Log ("moving to ?");
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


		if(Physics.Raycast(ray, out hit))
		{
			//hit.point.y = squad.agent.transform.position.y;

			Destination.x = hit.point.x;
			Destination.y = squad.agent.transform.position.y;
			Destination.z = hit.point.z;

			squad.transform.LookAt (Destination);
			squad.agent.SetDestination (Destination);

		}


	}


}