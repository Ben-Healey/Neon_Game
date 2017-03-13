using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverEnabler : MonoBehaviour {

	public bool isValid = false;
	public bool squadValid = false;
	public bool playerValid = false;

	GameObject player;
	GameObject[] squad;

	Ray checkRay;
	RaycastHit hit;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		squad = GameObject.FindGameObjectsWithTag ("Squad");

		checkRay.origin = gameObject.transform.position;
	}

	public bool CheckValid () 
	{
		isValid = false;

		checkPlayer ();
		checkSquad ();

		if (playerValid && squadValid)
		{
			isValid = true;
			Debug.Log ("isValid = " + isValid);
		}
		return isValid;
	}

	bool checkPlayer()
	{
		playerValid = false;

		checkRay.direction = player.transform.position - gameObject.transform.position;

		Physics.Raycast (checkRay, out hit, 50.0f);

		if(hit.collider.CompareTag("Player"))
			playerValid = true;
		
		Debug.Log ("playerValid = " + playerValid);
		return playerValid;
	}


	bool checkSquad()
	{
		squadValid = false;

		bool squadInvalid = false;

		for (int i = 0; i < squad.Length; i++)
			checkRay.direction = squad [i].transform.position - gameObject.transform.position;

		Physics.Raycast (checkRay, out hit, 50.0f);
		if (hit.collider.CompareTag ("Squad"))
			squadValid = true;

		//if (!squadInvalid)
		//	squadValid = true;

		Debug.Log ("squadValid = " + squadValid);
		return squadValid;
	}





	// Update is called once per frame
	//void Update () {
		
	//}
}
