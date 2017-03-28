using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Script : MonoBehaviour {

    GameObject Door_Anim;
	// Use this for initialization
	void Start () {
//		Animator Anim;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Door_Anim = GameObject.Find("SF_Door");
            Door_Anim.GetComponent<Animation>().Play("open");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Door_Anim = GameObject.Find("SF_Door");
            Door_Anim.GetComponent<Animation>().Play("close");
        }
    }
}
