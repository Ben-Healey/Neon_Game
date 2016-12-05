using UnityEngine;
using System.Collections;

public class Shader_Switch : MonoBehaviour {
	Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Standard");
	}

	public void switchOn(){
		Debug.Log ("SHADER CHANGE");
		rend.material.shader = Shader.Find ("Custom/Test_Shader");
	}


}
