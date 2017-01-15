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
		Destroy (this.gameObject);

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
}
