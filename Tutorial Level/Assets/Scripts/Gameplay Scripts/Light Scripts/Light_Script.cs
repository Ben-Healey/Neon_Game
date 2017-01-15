using UnityEngine;
using System.Collections;

public class Light_Script : MonoBehaviour {
	Light TestLight; 
	public Shader_Switch Script;

	// Use this for initialization
	void Start () {
		TestLight = GetComponentInChildren<Light> ();
		//Debug.Log ("LIGHT IS OFF");
		TestLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisonEnter(Collider col){
		Debug.Log ("col");
		if (col.gameObject.name == "Player") {
		//	Debug.Log ("LIGHT IS ON");
			TestLight.enabled = true;
			Script.switchOn();
		}
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("col");
		if (col.gameObject.tag == "Player") {
	//		Debug.Log ("LIGHT IS ON");
			TestLight.enabled = true;
			Script.switchOn();
		}
	}
}
