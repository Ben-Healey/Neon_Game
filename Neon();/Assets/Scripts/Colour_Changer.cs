using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour_Changer : MonoBehaviour {
    Renderer rend;
    public Material[] Mats;
    int Ran_num;
    float timer;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Ran_num = Random.Range(0, 3);
        //Debug.Log(Ran_num);
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            if (Ran_num == 0)
            {
                // Debug.Log(x);
                rend.material = Mats[0];
                gameObject.tag = "Blue_Light";

            }
            else if (Ran_num == 1)
            {
                rend.material = Mats[1];
                gameObject.tag = "Red Light";

            }
            else if (Ran_num == 2)
            {
                rend.material = Mats[2];
                gameObject.tag = "Green_Light";
            }
            timer = 0;
        }
    }

    
}
