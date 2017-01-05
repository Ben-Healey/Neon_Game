using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Draw_Script : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DrawT(){
		Debug.Log ("TEXT SHOULD APPEAR");
		GetComponent<Text> ().enabled = true;
	}
}
