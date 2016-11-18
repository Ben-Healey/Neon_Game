using UnityEngine;
using System.Collections;

public class Col : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Door") {
			Destroy (col.gameObject);
			Debug.Log("Collision has happened");
		}
	
	}

}
