using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Mouse_Script : MonoBehaviour {
	Text Test;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		Test = GetComponent<Text> ();
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		Test.material.color = Color.blue;
		//Test.material.color -= new Color(0.1f,0,0) * Time.deltaTime;

	}
	void OnMouseEnter()
	{
		Debug.Log ("Mouse Enter");
		Test.color = Color.yellow;
		//Test.material.color -= new Color(0.1f,0,0) * Time.deltaTime;

	}
}
