using UnityEngine;
using System.Collections;
//This Script is used to make the platform appears so the player can cross in to the combat training part of the level
public class Floor_Trig : MonoBehaviour {
	public GameObject childObject;
	float timeleft = 0;
	Renderer currentRenderer;

	void Start(){
		currentRenderer = GetComponentInChildren<Renderer> ();
		currentRenderer.enabled = false;
	}

	void Update(){
		timeleft = timeleft + Time.deltaTime; 
		if (timeleft >= 10 && transform.position.x >= 0) {
			currentRenderer.enabled = true;
			transform.Translate (Vector3.left * Time.deltaTime); 
			}
		if (transform.position.x == 0) {
			transform.Translate (Vector3.left * 0);
	}
}
}