using UnityEngine;
using System.Collections;

public class Ele : MonoBehaviour {
	
	public float force;
	public GameObject playerObject;
	void Start(){
		playerObject = GameObject.Find("Player");
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("ENTERS");
	}

	void OnTriggerStay(Collider other)
	{
		if (transform.position.y <= 9) {
			transform.Translate (Vector3.up * force);
			if (transform.position.y == 9) {
				OnTriggerExit (other);
				Debug.Log ("OBJECTS Y IS 9");
			}
		}

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("OBJECT HAS LEFT");
	}

}
