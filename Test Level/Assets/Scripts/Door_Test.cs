using UnityEngine;
using System.Collections;

public class Door_Test : MonoBehaviour {
	float timeleft = 5.0f;
	float movementSpeed = 1.0f;
	private AudioSource audio;
	void Start(){
		audio = GetComponent<AudioSource> ();
	}
	void Update(){
				
		timeleft -= Time.deltaTime;
		if (timeleft < 0 && transform.position.y >= -2.5f) {
			transform.Translate (Vector3.down * movementSpeed * Time.deltaTime); 
			if(transform.position.y == -2.5f){
				Stop ();
			}
		}
			
		}
	void Stop(){
		while (true) {
			transform.Translate (Vector3.down * 0); 
		}
	}

}
