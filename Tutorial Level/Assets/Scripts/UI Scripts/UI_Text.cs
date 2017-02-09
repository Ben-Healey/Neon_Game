﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;  
public class UI_Text : MonoBehaviour {
	string message;
	Text text;
	private float Pause = 0.2f;
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
		this.GetComponent<Text>().enabled = true;
		text = GameObject.Find("UICanvas").transform.FindChild("UI_Text").GetComponent<Text> ();
		message = System.IO.File.ReadAllText("Start.txt");
		text.text = "";
		StartCoroutine (TypeText ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Used to determine what ui text needs to be sent to the screen 
	public void Checker_Function(string x){
		if (x == "Light_Source") {
			Display_UI ();
			message = System.IO.File.ReadAllText ("Test.txt");
			text.text = "";
			StartCoroutine (TypeText ());
		}

		if (x == "Destoryed") {
			Display_UI ();
			message = System.IO.File.ReadAllText ("Puzzle.txt");
			text.text = "";
			StartCoroutine (TypeText ());
		}
	}
	//Simple Function to turn text ui element back on 
	void Display_UI(){
		this.GetComponent<Text> ().enabled = true;
	}
}
