using UnityEngine;
using System.Collections;

public class Spotted_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisonEnter(Collider col){
		Debug.Log ("col");
		if (col.gameObject.name == "Player") {
			Debug.Log ("Enters Camera Space");
			//TestLight.enabled = true;
		}
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("col");
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Enters Camera Space");
			//estLight.enabled = true;
		}
	}
}
