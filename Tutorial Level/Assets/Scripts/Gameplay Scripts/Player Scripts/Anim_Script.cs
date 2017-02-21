using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Script : MonoBehaviour {
	public AnimationClip idle;
	string idleN;
	// Use this for initialization
	void Start () {
//		Animator Anim;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Idle()
	{
		idleN = idle.name;

		GetComponent<Animation> ().Play (idleN);

	}
}
