using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Temp File for Demo
public class Temp_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	void OnMouseDown()
	{
		Debug.Log ("Mouse Down");
		switch (gameObject.name) {
		case "Continue":
			SceneManager.LoadScene ("Level_1");
			break;
		}

	}
}
