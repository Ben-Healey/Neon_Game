using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Checker : MonoBehaviour {
	public UI_Text Checker;
	bool blocker = false;
	bool blocker2 = false;
	//string CheckerString;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Global_Script.Destoryed_Targets == 3)
		{
			Global_Script.Destoryed_Targets += 1;
			Checker.Checker_Function ("Destoryed");	
		}
		if (Global_Script.Puzzle_Complete == true) {
			Global_Script.Puzzle_Complete = false;
			Checker.Checker_Function ("Puzzle_Complete");
		}
		if (Global_Script.Alarm == true) {
			Global_Script.Alarm = false;
			Checker.Checker_Function ("Alarm");
		}

	}
	//Checker to see what UI Text element is need 
	//uses triggers for this 
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Light_Source") {
			Checker.Checker_Function (other.gameObject.name);
		}

		if (other.gameObject.name == "Squad_Spawn") {
			Checker.Checker_Function (other.gameObject.name);
		}

		if (other.gameObject.name == "Sec_Trig") {
			Checker.Checker_Function (other.gameObject.name);
		}
	}
		
}
