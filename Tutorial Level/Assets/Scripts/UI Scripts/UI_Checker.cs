using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Checker : MonoBehaviour {
	public UI_Text Checker;
	bool blocker = false;
	//string CheckerString;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Global_Script.Destoryed_Targets == 3 && blocker == false)
		{
			blocker = true;
			Checker.Checker_Function ("Destoryed");	
		}
	}
	//Checker to see what UI Text element is need 
	//uses triggers for this 
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Light_Source") {
			Checker.Checker_Function (other.gameObject.name);
		}
	}
		
}
