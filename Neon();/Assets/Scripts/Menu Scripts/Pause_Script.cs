using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour {
	GameObject Pause_Menu;
	//GameObject Player_UI; //No Longer needed
	GameObject Code_Text;
    GameObject Gun;

	// Use this for initialization
	void Start () {
		Pause_Menu = GameObject.Find ("Pause");
		//Player_UI = GameObject.Find ("UICanvas");
        Gun = GameObject.Find("Gun");
		Pause_Menu.GetComponent<Canvas> ().enabled = false; // Error is thrown if object is left inactive need to rememeber to active it
	}

    void FixedUpdate()
    {
      
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("escape"))
        {
            Pause();
        }
    }

    void Pause()
    {
        Global_Script.Paused = true;
        Time.timeScale = 0;
        Pause_Menu.GetComponent<Canvas>().enabled = true;
        Gun.SetActive(false);
    }
	
	void OnMouseDown()
	{

        if (gameObject.name == "Resume")
        {
            Time.timeScale = 1;
            //	//Debug.Log ("Unpause");
            Global_Script.Paused = false;
            Gun.SetActive(true);
            Pause_Menu.GetComponent<Canvas>().enabled = false;
        } else if (gameObject.name ==  "Save")
        {
            Debug.Log("SAVE CODE NEEDED");
        } else if(gameObject.name == "Exit")
        {
            Time.timeScale = 1;
            Application.Quit();
        }


    }
}
