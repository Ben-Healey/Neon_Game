using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Crosshair_Script : MonoBehaviour {
	//No longer used as of 17/02/2017
//	Ray Test_Ray;
//	RaycastHit Test_Hit;
//	public player_stats P_Script;
//	public Shader_Switch S_Script;
//	public Image ColourBar;
//	bool hasColour;
//	GameObject Player_UI;
//	GameObject ColourObj;
//	GameObject Test;
//	AudioSource[] audio;
//	AudioSource laser;
//	string Colour = null;
//	public float clip = 6;
//	public float shot = 0;
//	//Need to Clean this file up!!! 
//	// Use this for initialization
//	void Start () {
//		Player_UI = GameObject.Find ("UICanvas");
//		audio = GetComponents<AudioSource> ();
//		laser = audio[1];
//		ColourObj = GameObject.Find ("Colour");
//		ColourBar = ColourObj.GetComponent<Image> ();
//	}
//	
//	// Update is called once per frame
//	// 
//	void Update () {
//		Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
//		Debug.DrawRay (transform.position, forward, Color.green);
//		Take_Func ();
//		Fire_Func ();
//		Puzzle ();
//		Inv ();
//	}
//
//	void Take_Func(){
//		if (Physics.Raycast (Test_Ray, out Test_Hit)) {
////			if (Test_Hit.collider.tag == "Green_Light") {
////				//Debug.Log ("Hitting Green Light");
////				//Debug.Log (Test_Hit.collider.tag);
////				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
////				if (Input.GetButtonDown ("Take")) {
////					Colour = Test_Hit.collider.tag;
////				//	Debug.Log ("Storing " + Colour);
////					P_Script.Store_Colour (Colour);
////					S_Script.switchoff (Colour);
////					ColourBar.color = Color.green;
////					hasColour = true;
////				}
//			}
//
////			if (Test_Hit.collider.tag == "Red Light") {
////				Debug.Log ("Hitting Red Light");
////				Debug.Log (Test_Hit.collider.tag);
////				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
////				if (Input.GetButtonDown ("Take")) {
////					//Debug.Log ("Taking Light");
////					Colour = Test_Hit.collider.tag;
////					//Debug.Log ("Storing " + Colour);
////					P_Script.Store_Colour (Colour);
////					S_Script.switchoff (Colour);
////					ColourBar.color = Color.red;
////					hasColour = true;
////				}
////			}
//
////			if(Test_Hit.collider.tag == "Blue_Light"){
////				Debug.Log ("Hitting Blue Light");
////				Debug.Log (Test_Hit.collider.tag);
////				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
////				if (Input.GetButtonDown ("Take")) {
////					Debug.Log ("Taking Light");
////					Colour = Test_Hit.collider.tag;
////					Debug.Log ("Storing " + Colour);
////					P_Script.Store_Colour (Colour);
////					S_Script.switchoff (Colour);
////					ColourBar.color = Color.blue;
////					hasColour = true;
////				}
////			}
////
//	
//	}
//
//
//	void Fire_Func(){
////			if (Test_Hit.collider.tag == "Enemy") {
////				Colour = P_Script.Get_Colour ();
////				if (Input.GetButtonDown ("Fire1") && Colour == "Red Light") {
////				shot = shot+1;
////				ColourBar.fillAmount -= 0.1666f;
////				Debug.Log (shot);
////					Test_Hit.transform.gameObject.GetComponentInChildren<Attributes> ().damage ();
////					laser.Play ();
////					if (shot == clip) {
////						shot = 0;
////						ColourBar.fillAmount = 1;
////						Debug.Log ("Colour Clip is now empty");
////						P_Script.Store_Colour (null);
////						hasColour = false;
////					}
////				}
////			}
////		Colour = P_Script.Get_Colour ();
////		if (Input.GetButtonDown ("Fire1") && Colour == "Green_Light") {
////			Debug.Log ("HEALING PLAYER");;
////		}
////		Colour = P_Script.Get_Colour ();
////		if (Input.GetButtonDown ("Fire1") && hasColour == true && Test_Hit.collider.tag != "Enemy") {
////			shot += 1;
////			ColourBar.fillAmount -= 0.1666f;
////			Debug.Log (ColourBar.fillAmount);
////			laser.Play ();
////			if (shot == clip) {
////				shot = 0;
////				ColourBar.fillAmount = 1;
////				Debug.Log ("Colour Clip is now empty");
////				P_Script.Store_Colour (null);
////				ColourBar.color = Color.white;
////				hasColour = false;
////			}
////		}
//		}
//
//	//Need to rewrite this function to make it clear and work with more puzzles 
//	void Puzzle(){
////		if (Physics.Raycast (Test_Ray, out Test_Hit)) {
////			if (Test_Hit.collider.tag == "Blue_Button" && Colour == "Blue_Light") {
////				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
////				if(Input.GetButtonDown("Fire1")){
////					P_Script.Store_Colour (null);
////					shot = 0;
////					hasColour = false;
////					ColourBar.color = Color.white;
////					Test_Hit.transform.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
////					GameObject k = GameObject.FindWithTag ("Laser");
////					Global_Script.Puzzle_Complete = true;
////					Destroy (k);
////				}
////			}
////		}
//	
//	}
//	//Not Currently Used By The Systems in the Game
//	//Will add later if time
//	void Inv(){
//		if(Input.GetButtonDown("Inventory")){
//			Debug.Log ("Open Inv!");
//			Player_UI.SetActive (false);
//		}
//
//	}
//		
}
