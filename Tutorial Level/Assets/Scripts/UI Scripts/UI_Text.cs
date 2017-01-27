using System.Collections;
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
		GetComponent<Text>().enabled = true;
		text = GetComponent<Text> ();
		message = System.IO.File.ReadAllText("Start.txt");
		text.text = "";
		StartCoroutine (TypeText ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter(Collider other)
	{
		Debug.Log ("UI COL");
		if (other.gameObject.name == "Light Source") {
			message = System.IO.File.ReadAllText ("Test.txt");
			text.text = "";
			StartCoroutine (TypeText ());
		}
	}

	void Display_UI(){
		this.GetComponent<Text> ().enabled = true;

		
	}
}
