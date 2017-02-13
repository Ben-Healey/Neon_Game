using UnityEngine;
using System.Collections;

public class Alarm_Script : MonoBehaviour {
	public AudioSource Alarm;
	// Use this for initialization
	void Start () {
		Alarm = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AlarmSetoff()
	{
		Debug.Log ("Alarm System Will Go Off!!!");
		Alarm.Play ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && gameObject.tag == "Button") {
			TurnAlarmOff ();
		}
	}

	public void TurnAlarmOff()
	{
		Alarm = GameObject.FindGameObjectWithTag ("Alarm").GetComponent<AudioSource> ();
		Alarm.Stop ();
	}
}
