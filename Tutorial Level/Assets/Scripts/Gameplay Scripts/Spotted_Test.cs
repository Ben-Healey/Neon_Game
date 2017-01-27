using UnityEngine;
using System.Collections;

public class Spotted_Test : MonoBehaviour {
	Light SpotL;
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
		if (col.gameObject.tag == "Player") {
				Debug.Log ("Enters Camera Space");
				SpotL.color = Color.yellow;
			StartCoroutine(ColourChange());

		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Leaves Camera Space");
			SpotL.color = Color.white;
		}
	}
}


