using UnityEngine;
using System.Collections;

public class Shader_Switch : MonoBehaviour {
	Renderer rend;
	public GameObject k;
	IEnumerator switchBack(){
		yield return new WaitForSeconds (1);
		Debug.Log ("Turning Back On");
		rend.material.shader = Shader.Find("Custom/Test_Shader");
	}

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		if (k.gameObject.name == "Red Light") {
			rend.material.shader = Shader.Find ("Standard");
		}
	}

	public void switchOn(){
		Debug.Log ("SHADER CHANGE");

		rend.material.shader = Shader.Find ("Custom/Test_Shader");
	}

	public void switchoff(){
		Debug.Log ("Shader is Off");
		rend.material.shader = Shader.Find ("Standard");
		StartCoroutine (switchBack ());
	}
}
