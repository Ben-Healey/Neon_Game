using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Crosshair_Script : MonoBehaviour {
	Ray Test_Ray;
	RaycastHit Test_Hit;
	public player_stats P_Script;
	public Shader_Switch S_Script;
	public Image ColourBar;
	GameObject ColourObj;
	GameObject Test;
	AudioSource[] audio;
	AudioSource laser;
	string Colour = null;
	public int h;
	public float clip = 6;
	public float shot = 0;
	// Use this for initialization
	void Start () {
		audio = GetComponents<AudioSource> ();
		laser = audio[1];
		ColourObj = GameObject.Find ("Colour");
		ColourBar = ColourObj.GetComponent<Image> ();
		//ColourBar = transform.Find ("UICanvas").FindChild ("ColourBG").FindChild ("Colour").GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);
		Take_Func ();
		Fire_Func ();
		Puzzle ();
	}

	void Take_Func(){
		if (Physics.Raycast (Test_Ray, out Test_Hit)) {
			if (Test_Hit.collider.tag == "Green_Light") {
				Debug.Log ("Hitting Green Light");
				Debug.Log (Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if (Input.GetButtonDown ("Take")) {
					Debug.Log ("Taking Light");
					Colour = Test_Hit.collider.tag;
					Debug.Log ("Storing " + Colour);
					P_Script.Store_Colour (Colour);
					S_Script.switchoff (Colour);
					ColourBar.color = Color.green;
				}
			}

			if (Test_Hit.collider.tag == "Red Light") {
				Debug.Log ("Hitting Red Light");
				Debug.Log (Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if (Input.GetButtonDown ("Take")) {
					Debug.Log ("Taking Light");
					Colour = Test_Hit.collider.tag;
					Debug.Log ("Storing " + Colour);
					P_Script.Store_Colour (Colour);
					S_Script.switchoff (Colour);
					ColourBar.color = Color.red;

				}
			}

			if(Test_Hit.collider.tag == "Blue_Light"){
				Debug.Log ("Hitting Blue Light");
				Debug.Log (Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if (Input.GetButtonDown ("Take")) {
					Debug.Log ("Taking Light");
					Colour = Test_Hit.collider.tag;
					Debug.Log ("Storing " + Colour);
					P_Script.Store_Colour (Colour);
					S_Script.switchoff (Colour);
					ColourBar.color = Color.blue;
				}
			}

	
	}
}

	void Fire_Func(){
			if (Test_Hit.collider.tag == "Enemy") {
				Colour = P_Script.Get_Colour ();
				Debug.Log ("Enemy In Sight");
				if (Input.GetButtonDown ("Fire1") && Colour == "Red Light") {
					Debug.Log ("Firing Colour");
					shot += 1;
					Test_Hit.transform.gameObject.GetComponentInChildren<Attributes> ().damage ();
					laser.Play ();
					if (shot == clip) {
						shot = 0;
						Debug.Log ("Colour Clip is now empty");
						P_Script.Store_Colour (null);
					}
				}
			}
		Colour = P_Script.Get_Colour ();
		if (Input.GetButtonDown ("Fire1") && Colour == "Green_Light") {
			Debug.Log ("HEALING PLAYER");;
		}
		Colour = P_Script.Get_Colour ();
		if (Input.GetButtonDown ("Fire1") && Colour == "Red Light") {
			Debug.Log ("Firing Blank");;
			shot += 1;
			ColourBar.fillAmount = shot/ clip;
			if (shot == clip) {
				shot = 0;
				Debug.Log ("Colour Clip is now empty");
				P_Script.Store_Colour (null);
				ColourBar.color = Color.white;
			}
		}
		}

	void Puzzle(){
		if (Physics.Raycast (Test_Ray, out Test_Hit)) {
			if (Test_Hit.collider.tag == "Blue_Button" && Colour == "Blue_Light") {
				Debug.Log ("Hitting Button");
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if(Input.GetButtonDown("Fire1")){
				Test_Hit.transform.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				GameObject k = GameObject.FindWithTag ("Laser");
				Destroy (k);
				}
			}
		}
	
	}
		
}
