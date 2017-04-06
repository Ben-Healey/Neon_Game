using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Script : MonoBehaviour {
    Ray ray;
    RaycastHit ray_hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out ray_hit))
        {
            if(ray_hit.collider.name == "Man_Hole")
            {
                if (Input.GetButtonDown("Use"))
                {
                    ray_hit.transform.Translate(Vector3.down * 5);
                }
            }
        }
	}
}
