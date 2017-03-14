using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour {
	public player_stats player_script;
	public Puzzle_Script Puzzle;
	public GameObject projectile;
	public GameObject projectile_B;
	public GameObject projectile_G;
	//public GameObject player_Dis;
	//public float Dis;
	GameObject bullet;
	GameObject bullet_B;
	GameObject bullet_G;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && player_script.Get_Colour () == "Red Light") {
			bullet = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			bullet.transform.Rotate (0, 270, 0);
			bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * 2000);
		}
		if (Input.GetButtonDown ("Fire1") && player_script.Get_Colour () == "Blue_Light")
		{
			bullet_B = (GameObject)Instantiate (projectile_B, transform.position, Quaternion.identity);
			bullet_B.GetComponent<Rigidbody> ().AddForce (transform.forward * 2000);
		}
		if (Input.GetButtonDown ("Fire1") && player_script.Get_Colour () == "Green_Light") {
			bullet_G = (GameObject)Instantiate (projectile_G, transform.position, Quaternion.identity);
			bullet_G.GetComponent<Rigidbody> ().AddForce (transform.forward * 2000);
		}
		Destroy (bullet, 5);
		Destroy (bullet_B, 5);
		Destroy (bullet_G, 5);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.transform.gameObject.GetComponentInChildren<Attributes> ().damage ();
			//Debug.Log ("Hiitng");
			Destroy (this.gameObject);
			//Debug.Log ("DESTORYED GAMEOBJECT");
		}

		if (other.gameObject.tag == "Blue_Button") {
			//May need to move the puzzle code to this function see if that destorys the blue bullet 
			Puzzle.Blue_Puzzle_Func ();
			Destroy (this.gameObject);
			Debug.Log ("Destory Blue Bullet");
		}
	}
}
