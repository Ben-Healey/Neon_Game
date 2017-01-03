using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Draw(){
		GetComponent<Text> ().enabled = true;
	}
}
