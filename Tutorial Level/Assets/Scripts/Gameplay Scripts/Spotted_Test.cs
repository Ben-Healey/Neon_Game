using UnityEngine;
using System.Collections;

public class Spotted_Test : MonoBehaviour {
	Light SpotL;
//	float tick = 0;
	private Alarm_Script A_Script;
	IEnumerator ColourChange(){
		yield return new WaitForSeconds (5);
		SpotL.color = Color.red;
		A_Script.AlarmSetoff ();
	}
	// Use this for initialization
	void Start () {
		SpotL = GetComponentInChildren<Light> ();
		A_Script = gameObject.GetComponent<Alarm_Script>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		//Debug.Log ("col");
		if (col.gameObject.tag == "Player") {
				Debug.Log ("Enters Camera Space");
			//	tick = Time.deltaTime;
				SpotL.color = Color.yellow;
			//WaitForSecondsRealtime (1);
			//SpotL.color = Color.red;
			StartCoroutine(ColourChange());

		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Leaves Camera Space");
		//	tick = Time.deltaTime;
			SpotL.color = Color.white;
		}
	}
}


