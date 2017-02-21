using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Checker : MonoBehaviour {
	public UI_Text Checker;
	string sceneName;
	Scene currentScene;
	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
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
			//Checker so the Alarm text only plays on the tutorial level
			if(sceneName == "Tutorial") {
			Checker.Checker_Function ("Alarm");
			}
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
		if (other.gameObject.name == "Combat_Trigger") {
			//Only loads next level as combat is not yet in, will instead load a text file once combat is in
			SceneManager.LoadScene("Set_Up");
		}
	}
		
}
