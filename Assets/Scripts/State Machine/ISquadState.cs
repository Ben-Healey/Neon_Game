using UnityEngine;
using System.Collections;

public interface ISquadState
{

	//EACH STATE NEEDS THE FOLLOWING FUNCTIONS
	//DELETE ONE HERE, REMOVE ITS FUNCTION FROM ALL STATES
	//ADD ONE HERE ADD ITS FUNCTION TO ALL STATES
	//THINK OF THIS LIKE A HEADER FILE WHICH ALL OF THE STATES INCLUDE
	//THIS SHIT IS CASE SENSITIVE BRUH
	//Also make sure to add to the StatePatternSquad file by the [HideInInspector] bit

	void UpdateState();

	void ToIdleState();

	void ToCoverState();

	void ToAttackState();


	//Order States
	void OrderAttackState();

	void OrderDefendState();

	void OrderMoveState();

	void OrderDestructState();

}