using UnityEngine;
using System.Collections;

public class Alarm_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AlarmSetoff()
	{
		Debug.Log ("Alarm System Will Go Off!!!");
	}

	void OnTriggerEnter(Collider other)
	{
		
	}
}
