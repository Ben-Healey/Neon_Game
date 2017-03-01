using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;  
public class Menu_Script : MonoBehaviour {
	private float Pause = 0.0f;
	GameObject Text_SO;
	GameObject Text_OO;
	GameObject Text_QO;
	TextAsset Title;
	string message; 
	Text textComp;
	Text Text_S;
	Text Text_O;
	Text Text_Q;
	AudioSource Audio;
	// Use this for initialization
	void Start () {
		Text_SO = GameObject.Find ("Start_Text"); 
		Text_OO = GameObject.Find ("Option_Text"); 
		Text_QO = GameObject.Find ("Quit_Text");

		Text_S = Text_SO.GetComponent<Text> ();
		Text_O = Text_OO.GetComponent<Text> ();
		Text_Q = Text_QO.GetComponent<Text> ();

		Text_S.enabled = false;
		Text_O.enabled = false;
		Text_Q.enabled = false;

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
		Text_S.enabled = true;
		Text_O.enabled = true;
		Text_Q.enabled = true;
	}



	public void Draw(){
		GetComponent<Text> ().enabled = true;

	
		textComp = GetComponent<Text> ();
		message = System.IO.File.ReadAllText("Assets/Text Files/Title.txt");
		//textComp.text;
		textComp.text = "";
		StartCoroutine (TypeText ());
		Audio.Play ();
	}
}
