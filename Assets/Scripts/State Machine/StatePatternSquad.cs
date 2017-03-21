using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class StatePatternSquad : MonoBehaviour
{
	public float sightRange = 20f;
	public float speed = 10.0f;

	public List<GameObject> coverList;// = new List<GameObject> ();
	public List<GameObject> validCover;// = new List<GameObject> ();

//	public GameObject squad;
//	public GameObject enemy;

	public bool MoveTo;

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

	public NavMeshAgent agent;
	public Animator myAnimator;


	private void Awake()
	{
		coverState = new CoverState (this);
		idleState = new IdleState (this);
		attackState = new AttackState (this);
		orderMoveState = new Order_MoveState (this);

		myAnimator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		coverList = new List<GameObject> ();
		validCover = new List<GameObject> ();
	}


	// Use this for initialization
	void Start ()
	{
		currentState = idleState;
		//currentState = orderMoveState;
		MoveTo = GetComponent<characterController> ().getMOVETO();
	//	squad = GameObject.FindGameObjectsWithTag ("squad");
	//	enemy = GameObject.FindGameObjectsWithTag ("enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (MoveTo == true)
		{
			currentState = orderMoveState;
		}

		currentState.UpdateState ();

		//Debug.Log(currentState);
	}



	void OnTriggerEnter (Collider _collision)
	{
		if (_collision.gameObject.CompareTag ("Cover"))
		{
		//Debug.Log ("adding to list");
		coverList.Add (_collision.gameObject);
		}
	}

	void OnTriggerExit (Collider _collision)
	{
		if (_collision.gameObject.CompareTag ("Cover"))
		{
			if(validCover.Contains(_collision.gameObject))
				validCover.Remove(_collision.gameObject);
			//Debug.Log ("removing from list");
			coverList.Remove (_collision.gameObject);
		}
	}

}
