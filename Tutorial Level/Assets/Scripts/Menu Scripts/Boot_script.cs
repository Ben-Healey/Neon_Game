using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Boot_script : MonoBehaviour {
	private float Pause = 0.0f;
	GameObject M_Menu;
	Log_Script Menu;
	string message; 
	Text textComp;

	// Use this for initialization
	void Start () {
		M_Menu = GameObject.FindGameObjectWithTag ("Log");
		Menu = M_Menu.GetComponent<Log_Script> ();
		textComp = GetComponent<Text> ();
		message = textComp.text;
		textComp.text = "";
		StartCoroutine (TypeText ());
	}

	IEnumerator TypeText(){
		foreach (char letter in message.ToCharArray()) {
			textComp.text += letter;
			yield return new WaitForSeconds (Pause);
		}
		Debug.Log ("Finished Typing Fading Out");
		Menu.Draw ();
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
