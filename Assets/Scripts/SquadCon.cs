using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadCon : MonoBehaviour {

	bool x = false;
	public NavMeshAgent agent;
	GameObject player;
	float vSpeed = 0;
	Animator myAnimator;
	Vector3 loc;

	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		myAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
        loc = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (x == true) {
			this.agent.SetDestination (player.transform.position);
			this.myAnimator.SetFloat ("VSpeed", vSpeed++);
		} 
		if (x == false)
		{
            this.agent.SetDestination (loc);
			vSpeed = 0;
		}
	}

	public void fol()
	{
		Debug.Log ("x = " + x);
		if (x == true)
			x = false;
		else
			x = true;
	}
}
