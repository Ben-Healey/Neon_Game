using UnityEngine;
using System.Collections;

public class Crosshair_Script : MonoBehaviour {
	Ray Test_Ray;
	RaycastHit Test_Hit;
	// Use this for initialization
	void Start () {
		Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);

	}
	
	// Update is called once per frame
	void Update () {
		//Test_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);
		if(Physics.Raycast(Test_Ray,out Test_Hit))
		{
			if (Test_Hit.collider.tag == "Green_Light") {
				print (Test_Hit.collider.tag);
				Debug.DrawLine (Test_Ray.origin, Test_Hit.point);
			}
			//Debug.DrawRay (transform.position, forward, Color.green);
		}
		if (Input.GetButtonDown("Take")){
			Debug.Log ("Taking Light");
			//if(Physics.Raycast(Test_Ray,out Test_Hit))
			//{
			//	print (Test_Hit.collider.tag);
			//	Debug.DrawRay (transform.position, forward, Color.green);
			//}
		}

		
	}
}
