using UnityEngine;
using System.Collections;

public class Shader_Switch : MonoBehaviour {
	//Problem: Shader only change colour on the red object other objects arent effected in game world


	Renderer rend;
	public GameObject k;
	IEnumerator switchBack(string K){
		yield return new WaitForSeconds (1);
		Debug.Log ("Turning Back On");
		if (K == "Red Light") {
			rend.material.shader = Shader.Find ("Custom/Red_Shader");
		}
		if (K == "Green Light") {
			rend.material.shader = Shader.Find ("Custom/Green_Shader");
		}
	}

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		if (k.gameObject.tag == "Red_Light") {
			rend.material.shader = Shader.Find ("Standard");
		}
		if (k.gameObject.tag == "Green_Light") {
			rend.material.shader = Shader.Find ("Standard");
		}
	}

	public void switchOn(){
		Debug.Log ("SHADER CHANGE");

		rend.material.shader = Shader.Find ("Custom/Red_Shader");
	}

	public void switchoff(string Colour){
		string K = Colour;
		Debug.Log ("Shader is Off");
		Debug.Log ("K = " + K);
		rend.material.shader = Shader.Find ("Standard");
		StartCoroutine (switchBack (K));
	}
}
