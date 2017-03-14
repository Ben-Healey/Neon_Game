﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;  
using UnityEngine.SceneManagement;
public class UI_Text : MonoBehaviour {
	string message;
	Text text;
	private float Pause = 0.2f;
	string sceneName;
	public TextAsset Start_text,
					 Light_text,
					 Destroyed_text,
					 Puzzle_text,
					 Squad_text,
					 Sec_text,
					 Alarm_text,
					 Combat_text;
	Scene currentScene;

	IEnumerator TypeText(){
		foreach (char letter in message.ToCharArray()) {
			text.text += letter;
			yield return new WaitForSeconds (Pause);
		}
		yield return new WaitForSeconds (2.0f);
		text.text = null;
		this.GetComponent<Text> ().enabled = false;
	}

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;

		this.GetComponent<Text>().enabled = true;
		text = GameObject.Find("UICanvas").transform.FindChild("UI_Text").GetComponent<Text> ();
		if (sceneName == "Tutorial") {
			//loaded_text = (TextAsset)Resources.Load ("Start.txt", typeof(TextAsset));
			message = Start_text.ToString();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Start.txt");
			text.text = "";
			StartCoroutine (TypeText ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Used to determine what ui text needs to be sent to the screen 
	public void Checker_Function(string x){
		if (x == "Light_Source") {
			Display_UI ();
			//loaded_text = (TextAsset)Resources.Load ("Test", typeof(TextAsset));
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Test.txt");
			//message = loaded_text.ToString();
			message = Light_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}

		if (x == "Destoryed") {
			Display_UI ();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Puzzle.txt");
			message = Destroyed_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}
		if (x == "Puzzle_Complete") {
			Display_UI ();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Next.txt");
			message = Puzzle_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}

		if (x == "Squad_Spawn") {
			Display_UI ();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Sqaud.txt");
			message = Puzzle_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}

		if (x == "Sec_Trig") {
			Display_UI ();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Sec.txt");
			message = Sec_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}
		if (x == "Alarm") {
			Display_UI ();
			//message = System.IO.File.ReadAllText ("Assets/Text Files/Alarm.txt");
			message = Alarm_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
		}
		if (x == "Combat_Trigger") {
			Display_UI ();
			message = Combat_text.ToString();
			text.text = "";
			StartCoroutine (TypeText ());
			return;
		}
	}
	//Simple Function to turn text ui element back on 
	void Display_UI(){
		this.GetComponent<Text> ().enabled = true;
	}
}
