using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour {
	public AudioMixer audioMaster;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			Debug.Log ("Setting Sound level");
			audioMaster.SetFloat ("Cutoff_freq", 5000);
		}
	}
}
