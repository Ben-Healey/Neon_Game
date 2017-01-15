using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mouse_Script : MonoBehaviour {
	GameObject Text_S;
	GameObject Text_O;
	GameObject Text_Q;
	Text Text;
	AudioSource Audio;
	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		Debug.Log ("Mouse Enter");
		//Need to add text effect on mouse over
		//Test.material.color = Color.blue;
		//Test.material.color -= new Color(0.1f,0,0) * Time.deltaTime;

	}


	void OnMouseDown(){
		Debug.Log ("Mouse Down");
		switch (gameObject.name) {
		case "Start_Text":
			Audio.Play ();
			SceneManager.LoadScene ("Tutorial");
			break;
		case "Option_Text":
			Audio.Play ();
			Debug.Log ("Options Not Done");
			break;
		case "Quit_Text":
			Audio.Play ();
			Debug.Log ("Quitting");
			Application.Quit ();
			break;
		}
	}

}
