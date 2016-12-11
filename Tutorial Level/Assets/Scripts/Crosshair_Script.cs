using UnityEngine;
using System.Collections;

public class Crosshair_Script : MonoBehaviour {
	Ray Test_Ray;
	RaycastHit Test_Hit;
	public player_stats P_Script;
	string Colour = null;
	// Use this for initialization
	void Start () {
		//Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);
		if(Physics.Raycast(Test_Ray,out Test_Hit))
		{
			if (Test_Hit.collider.tag == "Green_Light") {
				Debug.Log ("Hitting Green Light");
				Debug.Log(Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if (Input.GetButtonDown("Take")){
					Debug.Log ("Taking Light");
					Colour = Test_Hit.collider.tag;
					Debug.Log ("Storing " + Colour);
					P_Script.Store_Colour(Colour);
				}
			}
			if (Test_Hit.collider.tag == "Red Light") {
				Debug.Log ("Hitting Red Light");
				Debug.Log(Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
				if (Input.GetButtonDown("Take")){
					Debug.Log ("Taking Light");
					Colour = Test_Hit.collider.tag;
					Debug.Log ("Storing " + Colour);
					P_Script.Store_Colour(Colour);
				}
			}
		}



	}
}
