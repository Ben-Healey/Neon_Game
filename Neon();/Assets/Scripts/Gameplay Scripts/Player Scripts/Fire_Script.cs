using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fire_Script : MonoBehaviour {
	Ray ray;
	RaycastHit ray_hit;
	//public GameObject projectile;
	public player_stats player_script;
	public Anim_Script Anim;
	public static AnimationClip shoot;
	Image ColourBar;
	new AudioSource[] audio;
	AudioSource laser;
	string Colour = null;
	float clipSize = 6;
	public static float shot = 0;
	//public AnimationClip idle;
	// Use this for initialization
	void Start () {
		GameObject ColourObj = GameObject.Find ("Colour");
		ColourBar = ColourObj.GetComponent<Image> ();
	
		audio = GetComponents<AudioSource> ();
		laser = audio [1];
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
		Debug.DrawRay (transform.position, forward, Color.green);
		if (Physics.Raycast (ray, out ray_hit)) {
			if (ray_hit.collider.tag == "Enemy") {
				Fire_Enemy ();
				Debug.Log ("Hitting Enemy");
			}

			Colour = player_script.Get_Colour ();
			if (Input.GetButtonDown ("Fire1") && Colour == "Green") {
				Heal ();
			}

			if (Input.GetButtonDown ("Fire1") && player_script.gethasColour () == true && ray_hit.collider.tag != "Enemy") {
				Fire ();
			}
		}
	}

	void Fire_Enemy()
	{
		//Colour = player_script.Get_Colour ();
		if(Input.GetButtonDown("Fire1") && player_script.Get_Colour() == "Red Light")
		{
			//GameObject bullet = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			//bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * 10);
			shot += 1;
			ColourBar.fillAmount -= 0.1666f;
			//May need to change when 
			//ray_hit.transform.gameObject.GetComponentInChildren<Attributes> ().damage ();
			laser.Play ();

			if (shot == clipSize) {
				shot = 0;
				ColourBar.fillAmount = 1;
				player_script.Store_Colour (null);
				player_script.sethasColour (false);
				ColourBar.color = Color.white;
			}
		}
	}

	void Fire()
	{
		shot += 1;
		ColourBar.fillAmount -= 0.16666f;
		laser.Play ();
		if (shot == clipSize) {
			shot = 0;
			ColourBar.fillAmount = 1;
			player_script.Store_Colour (null);
			ColourBar.color = Color.white;
			player_script.sethasColour (false);
		}
	}

	void Heal()
	{
		if (ray_hit.collider.tag == "Sqaud") {
			Debug.Log ("Healing Sqaud Member");
		} else {
            float currrenthealth = player_script.getHealth();
            player_script.setHealth(currrenthealth + 10); 

		}
	}
}
