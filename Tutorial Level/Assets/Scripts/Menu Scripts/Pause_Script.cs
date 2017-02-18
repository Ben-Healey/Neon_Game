using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour {
	GameObject Pause_Menu;
	GameObject Player_UI;
	GameObject Code_Text;

	// Use this for initialization
	void Start () {
		Pause_Menu = GameObject.Find ("Pause");
		Player_UI = GameObject.Find ("UICanvas");
		Pause_Menu.GetComponent<Canvas> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("escape")) {
			Debug.Log ("Entered Pause Menu");
			Global_Script.Paused = true;
			Debug.Log (Global_Script.Paused);
			Time.timeScale = 0;
			Pause_Menu.GetComponent<Canvas> ().enabled = true;
			OnMouseDown ();
		}
	}
	//Bug: If built and ran and player try to load the pause menu the game will just close
	//Need to fix 
	void OnMouseDown()
	{
		switch (gameObject.name) {
		case "Resume":
			Time.timeScale = 1;
			Debug.Log ("Unpause");
			Global_Script.Paused = false;
			Pause_Menu.GetComponent<Canvas> ().enabled = false;
			break;
		case "Save":
			Debug.Log ("Need Save Code");
			break;
		case "Exit":
			Debug.Log ("Quiting");
			Time.timeScale = 1;
			Application.Quit ();
			break;
			}

		}
}
