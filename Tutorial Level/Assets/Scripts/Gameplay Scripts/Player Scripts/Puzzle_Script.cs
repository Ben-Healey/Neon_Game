using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Script : MonoBehaviour {
	Ray ray;
	RaycastHit ray_hit;
	public player_stats player_script;
	Image ColourBar;
	new AudioSource[] audio;
	AudioSource laser;
	//float clipSize_Puzzle = 1;
	//float shot = 0;

	// Use this for initialization
	void Start () {
		audio = GetComponents<AudioSource> ();
		laser = audio[1];
		GameObject ColourObj = GameObject.Find ("Colour");
		ColourBar = ColourObj.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (ray, out ray_hit)) {
			if(ray_hit.collider.tag == "Blue_Button" && player_script.Get_Colour () == "Blue_Light" && (Input.GetButtonDown ("Fire1"))){
				Blue_Puzzle_Func ();
				laser.Play ();
			}
		}

	}


	public void Blue_Puzzle_Func()
	{
		player_script.Store_Colour (null);
		player_script.sethasColour (false);
		ColourBar.color = Color.white;
		ray_hit.transform.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		GameObject Laser = GameObject.FindWithTag ("Laser");
		Global_Script.Puzzle_Complete = true;
		Destroy (Laser);

	}

}
