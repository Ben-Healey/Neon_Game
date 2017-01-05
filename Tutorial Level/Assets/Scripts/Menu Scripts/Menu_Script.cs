using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_Script : MonoBehaviour {
	private float Pause = 0.0f;
	string message; 
	Text textComp;
	AudioSource Audio;
	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
		Audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TypeText(){
		foreach (char letter in message.ToCharArray()) {
			textComp.text += letter;
			yield return new WaitForSeconds (Pause);
		}
		Debug.Log ("Finished Typing Fading Out");
	}

	public void Draw(){
		GetComponent<Text> ().enabled = true;
		textComp = GetComponent<Text> ();
		message = textComp.text;
		textComp.text = "";
		StartCoroutine (TypeText ());
		Audio.Play ();
	}
}
