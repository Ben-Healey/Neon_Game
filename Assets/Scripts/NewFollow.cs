using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NewFollow : MonoBehaviour {

	NavMeshAgent agent;

	public GameObject player;
	public float speed;
	public float minRange = 2.0f;
	public float maxRange = 30.0f;
	public float separation;
	public Vector3 DistancE;
	public Vector3 targetDir;
	float minOne = -1;
	Vector3 newDir;

	// Use this for initialization
	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		speed = 3 * Time.deltaTime;
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		follow ();
	}

	private void follow()
	{

		targetDir = player.transform.position - transform.position;
		DistancE.x = player.transform.position.x - transform.position.x;
		DistancE.z = player.transform.position.z - transform.position.z;

		if(DistancE.x <=  0)
			DistancE.x = DistancE.x * minOne;

		if(DistancE.z <=  0)
			DistancE.z = DistancE.z * minOne;

		//PYTHAGORAS FOR SEPARATION BETWEEN PLAYER AND SQUAD
		separation = (DistancE.x * DistancE.x) + (DistancE.z * DistancE.z);
		separation = Mathf.Sqrt (separation);


		if ((separation >= minRange) && (separation <= maxRange))
		{
			newDir = Vector3.RotateTowards (transform.forward, targetDir, speed, 0.0f);
			Debug.DrawRay (transform.position, newDir, Color.red);
			transform.rotation = Quaternion.LookRotation (newDir);
			agent.SetDestination (player.transform.position);
		}
	}
}
