using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Log_Script : MonoBehaviour {
	private float Pause = 0.2f;
	string message; 
	Text textComp;
	GameObject Menu;
	GameObject D_Menu;

	Draw_Script DrawT;
	Menu_Script Menu_S;

	AudioSource Type;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
		Type = GetComponent<AudioSource> ();
		D_Menu = GameObject.FindGameObjectWithTag ("Draw");
		DrawT = D_Menu.GetComponent<Draw_Script> ();

		Menu = GameObject.FindGameObjectWithTag ("Menu");
		Menu_S = Menu.GetComponent<Menu_Script> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Draw(){
		GetComponent<Text> ().enabled = true;
		DrawT.DrawT ();
		textComp = GetComponent<Text> ();
		message = textComp.text;
		textComp.text = "";
		StartCoroutine (TypeText ());
	
	}
	IEnumerator TypeText(){
		Type.Play ();
		foreach (char letter in message.ToCharArray()) {
			textComp.text += letter;
			yield return new WaitForSeconds (Pause);
		}
		Debug.Log ("Finished Typing Fading Out");
		Type.Stop ();
		Menu_S.Draw ();
		Destroy (gameObject);
	}
}
