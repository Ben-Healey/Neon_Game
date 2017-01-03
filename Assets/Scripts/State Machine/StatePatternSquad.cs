using UnityEngine;
using System.Collections;

public class StatePatternSquad : MonoBehaviour
{
	//public Transform eyes = this;
	public float sightRange = 20f;
	public float speed = 10.0f;


//	public GameObject squad;
//	public GameObject enemy;



	[HideInInspector] public Transform followPlayer;
	[HideInInspector] public ISquadState currentState;
	[HideInInspector] public CoverState coverState;
	[HideInInspector] public IdleState idleState;
	[HideInInspector] public AttackState attackState;

	//Order States
	[HideInInspector] public Order_AttackState orderAttackState;
	[HideInInspector] public Order_DefendState orderDefendState;
	[HideInInspector] public Order_MoveState orderMoveState;
	[HideInInspector] public Order_DestructState orderDestructState;

	[HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;


	private void Awake()
	{
		coverState = new CoverState (this);
		idleState = new IdleState (this);
		attackState = new AttackState (this);

		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}


	// Use this for initialization
	void Start ()
	{
		currentState = idleState;
	//	squad = GameObject.FindGameObjectsWithTag ("squad");
	//	enemy = GameObject.FindGameObjectsWithTag ("enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentState.UpdateState ();

		Debug.Log(currentState);
	}

}
