using UnityEngine;
using System.Collections;

public class Floor_Trig : MonoBehaviour {
	public GameObject childObject;
	float timeleft = 0;
//	float movementSpeed = 1.0f;
	Renderer currentRenderer;
	//public Transform ff;
	void Start(){
		currentRenderer = GetComponentInChildren<Renderer> ();
		currentRenderer.enabled = false;
	}

	void Update(){
		timeleft = timeleft + Time.deltaTime; 
		if (timeleft >= 10 && transform.position.x >= 0) {
		//	Debug.Log ("PLATFOM SHOULD APPEAR");
			currentRenderer.enabled = true;
			transform.Translate (Vector3.left * Time.deltaTime); 
			}
		if (transform.position.x == 0) {
		//	Debug.Log ("PLATFOM SHOULD STOP");
			transform.Translate (Vector3.left * 0);
	}
}
}