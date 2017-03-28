using UnityEngine;
using System.Collections;
//Script can be used to turn lights off with in a screen
public class Light_Script : MonoBehaviour {
	Light TestLight; 
	public Shader_Switch Script;

	// Use this for initialization
	void Start () {
		TestLight = GetComponentInChildren<Light> ();
		TestLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisonEnter(Collider col){
		if (col.gameObject.name == "Player") {
			TestLight.enabled = true;
			Script.switchOn();
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			TestLight.enabled = true;
			Script.switchOn();
		}
	}
}
