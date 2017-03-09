using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour {
	public player_stats player_script;
	public GameObject projectile;
	public GameObject player_Dis;
	public float Dis;
	GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Dis = Vector3.Distance (bullet.transform.position, player_Dis.transform.position);
		//Debug.Log (Dis);
		if (Input.GetButtonDown ("Fire1") && player_script.Get_Colour () == "Red Light") {
			bullet = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			bullet.transform.Rotate (0, 270, 0);
			bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * 2000);
		}
		Dis = Vector3.Distance (bullet.transform.position, player_Dis.transform.position);
		if (Dis >= 50) {
			Debug.Log ("Deleted Bullet");
			Destroy (bullet);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.transform.gameObject.GetComponentInChildren<Attributes> ().damage ();
			Debug.Log ("Hiitng");
		}
	}
}
