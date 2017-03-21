using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour {
	GameObject Pause_Menu;
	GameObject Player_UI;
	GameObject Code_Text;

	// Use this for initialization
	void Start () {
		Pause_Menu = GameObject.Find ("Pause");
		Player_UI = GameObject.Find ("UICanvas");
		Pause_Menu.GetComponent<Canvas> ().enabled = false; // Error is thrown if object is left inactive need to rememeber to active it :L
	}

    void FixedUpdate()
    {
      
    }
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown ("escape")) {
        //          //Debug.Log ("Entered Pause Menu");
        //          //Global_Script.Paused = true;
        //          //Debug.Log (Global_Script.Paused);
        //          //Time.timeScale = 0;
        //          //Pause_Menu.GetComponent<Canvas> ().enabled = true;
        //          //OnMouseDown ();
        //          Pause();
        //}
        if (Input.GetButtonDown("escape"))
        {
            Pause();
        }
    }

    void Pause()
    {
        //Debug.Log("Entered Pause Menu");
        Global_Script.Paused = true;
        Debug.Log(Global_Script.Paused);
        Time.timeScale = 0;
        Pause_Menu.GetComponent<Canvas>().enabled = true;
       //OnMouseDown();
    }
	
	void OnMouseDown()
	{

        if (gameObject.name == "Resume")
        {
            Time.timeScale = 1;
            //	//Debug.Log ("Unpause");
            Global_Script.Paused = false;
            Pause_Menu.GetComponent<Canvas>().enabled = false;
        } else if (gameObject.name ==  "Save")
        {
            Debug.Log("SAVE CODE NEEDED");
        } else if(gameObject.name == "Exit")
        {
            Time.timeScale = 1;
            Application.Quit();
        }
        //switch (gameObject.name)
        //{
        //    case "Resume":
        //        Time.timeScale = 1;
        //        //Debug.Log ("Unpause");
        //        Global_Script.Paused = false;
        //        Pause_Menu.GetComponent<Canvas>().enabled = false;
        //        break;
        //    case "Save":
        //        //Debug.Log ("Need Save Code");
        //        break;
        //    case "Exit":
        //        //	Debug.Log ("Quiting");
        //        Time.timeScale = 1;
        //        Application.Quit();
        //        break;
        //}

    }
}
