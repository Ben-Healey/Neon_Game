using UnityEngine;
using System.Collections;

public class Floor_Movement : MonoBehaviour {
	public GameObject Floor;
	Renderer currentRender;
	// Use this for initialization
	void Start () {
		currentRender = GetComponent<Renderer> ();
		currentRender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
