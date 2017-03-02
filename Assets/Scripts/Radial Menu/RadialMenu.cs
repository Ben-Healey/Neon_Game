using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour {

	private canMouseLook myCam;
	private bool showing;
	public GameObject Canvas;


	// Use this for initialization
	void Start ()
	{
		showing = false;
		Canvas.SetActive (showing);

		myCam = GetComponent<canMouseLook> ();
	}


	void Update ()
	{
		if (Input.GetKey ("q")) {
			Debug.Log ("Q PRESSED");

			myCam.enabled = !myCam.enabled;	//disable canMouseLook script

			Time.timeScale = 0.05f;	//change scale of time so it slows

			showing = true;	//bool for canvas
			Canvas.SetActive (showing);	//displays the canvas if bool is true

			Cursor.visible = true;	//makes the cursor visible
			Cursor.lockState = CursorLockMode.None;	//unlocks cursor movement
		}

		if (Input.GetKeyUp ("q"))
		{
			Debug.Log ("Q RELEASED");

			Time.timeScale = 1.0f;	//change scale of time so its normal

			showing = false;	//bool for canvas
			Canvas.SetActive (showing);	//stops displaying canvas if bool is false



			Cursor.visible = false;	//hides the cursor
			Cursor.lockState = CursorLockMode.Locked; //locks cursor movement
		}

		if (myCam.enabled == !myCam.enabled)
		{	// **SHOULD** check if canMouseLook script is disabled but doesn't seem to
			//MIGHT ACTUALLY WORK NOW
			Debug.Log("cam control was off");
			myCam.enabled = myCam.enabled;
			Debug.Log("cam control on");
		}
	}
}
