using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour {
						  //IPointerEnterHandler,
						  //IPointerExitHandler,
						  //IPointerClickHandler {

	public List<MenuButton> buttons = new List<MenuButton> ();
	private Vector2 mousePos;

	//Not sure if i need these
	//**
	private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);	//from top middle of screen
	private Vector2 centreCircle = new Vector2(1.5f, 1.5f); //not a clue
	private Vector2 toVector2M;								//mouse position?
	//**

	private canMouseLook myCam;
	private bool showing;

	public GameObject Canvas;
//	public GameObject[] canvas;

	public int menuItems;
	public int currentMenuItem;
	public int oldMenuItem;


	// Use this for initialization
	void Start ()
	{
		menuItems = buttons.Count;
		foreach (MenuButton button in buttons)
		{
			button.sceneImage.color = button.normalColor;
		}
		currentMenuItem = 0;
		oldMenuItem = 0;

		//canvas = GameObject.FindGameObjectsWithTag ("Radial");

		showing = false;
		Canvas.SetActive (showing);

		myCam = GetComponent<canMouseLook> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		getCurrentMenuItem ();

		//if (Input.GetButtonDown ("Fire1"))
		//{
		//	ButtonAction ();
		//}



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

		if (myCam.enabled == !myCam.enabled) {	// **SHOULD** check if canMouseLook script is disabled but doesn't seem to
			Debug.Log("cam control was off");
			myCam.enabled = myCam.enabled;
			Debug.Log("cam control on");
		}

	}
	/*
	public void getCurrentMenuItem()
	{
		mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);


		Vector2 relative = transform.InverseTransformPoint (mousePos);

		float angle = Mathf.Atan2 (relative.x, relative.y) * Mathf.Deg2Rad;

		currentMenuItem = (int) (angle / (360 / menuItems));
	}
*/


	/*
	public void getCurrentMenuItem()
	{
		
		mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

		for(int i = 0; i < menuItems; i++)
		{
			canvas [i].GetComponent<RectTransform> ();
			canvas [i].GetComponent<RectTransform> ();
		}
		
		foreach (MenuButton button in buttons)
		{

		}
	}
	*/



	public void getCurrentMenuItem()
	{
		mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.x);

		toVector2M = new Vector2 (mousePos.x / Screen.width, mousePos.y / Screen.height);

		float angle = (Mathf.Atan2 (fromVector2M.y - centreCircle.y, fromVector2M.x - centreCircle.x) - Mathf.Atan2 (toVector2M.y - centreCircle.y, toVector2M.x - centreCircle.x)) * Mathf.Rad2Deg;

		if (angle < 0)
			angle += 360;
		
		currentMenuItem = (int) (angle / (360 / menuItems));



		if (currentMenuItem != oldMenuItem)
		{
			buttons [oldMenuItem].sceneImage.color = buttons [oldMenuItem].normalColor;
			oldMenuItem = currentMenuItem;

			buttons [currentMenuItem].sceneImage.color = buttons [currentMenuItem].highlightedColor;
		}
	}


	public void ButtonAction()
	{
		buttons [currentMenuItem].sceneImage.color = buttons [currentMenuItem].pressedColor;

		if (currentMenuItem == 0)
		{
			print ("0");
		}
	}

	
}

[System.Serializable]

public class MenuButton
{
	public string name;
	public Image sceneImage;
	public Color normalColor = Color.white;
	public Color highlightedColor = Color.grey;
	public Color pressedColor = Color.gray;
}