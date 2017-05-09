using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Take_Script : MonoBehaviour {
	//Script used to take a light from the enviorment

	Ray ray;
	RaycastHit ray_hit;
	public player_stats player_script;
	public Image ColourBar;
	string Colour = null;
	public Fire_Script Fire;
	// Use this for initialization
	void Start () {
		GameObject ColourObj = GameObject.Find ("Colour");
		ColourBar = ColourObj.GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
		Debug.DrawRay (transform.position, forward, Color.green);

		if(Physics.Raycast (ray, out ray_hit)){
			if (ray_hit.collider.tag == "Red Light") {
				Red_Light (ray_hit.collider.tag);	
			}
			if (ray_hit.collider.tag == "Blue_Light") {
				Blue_Light (ray_hit.collider.tag);
			}
			if (ray_hit.collider.tag == "Green_Light") {
				Green_Light (ray_hit.collider.tag);
			}
		}

	}

	void Red_Light(string c)
	{
		if (Input.GetButtonDown ("Take")) {
			player_script.Store_Colour (c);
			ColourBar.color = Color.red;
			player_script.sethasColour (true);
			if (player_script.gethasColour() == true && Input.GetButtonDown("Take")) {
				ColourBar.fillAmount = 1;
				Fire_Script.shot = 0;
				//Debug.Log (Fire_Script.shot);
			}
		}
	}

	void Green_Light (string c)
	{
		if(Input.GetButtonDown("Take"))
		{
			player_script.Store_Colour (c);
			//ColourBar.fillAmount = 1;
			//Fire.shot = 0;
			ColourBar.color = Color.green;
			player_script.sethasColour (true);

			if (player_script.gethasColour () == true && Input.GetButtonDown ("Take")) {
				ColourBar.fillAmount = 1;
				Fire_Script.shot = 0;
			}
		}
	}

	void Blue_Light(string c)
	{
		if (Input.GetButtonDown ("Take")) {

			player_script.Store_Colour (c);
			ColourBar.color = Color.blue;
			player_script.sethasColour (true);

			if (player_script.gethasColour () == true && Input.GetButtonDown ("Take")) {
				ColourBar.fillAmount = 1;
				Fire_Script.shot = 0;
			}
		}
	}
}
