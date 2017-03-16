using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover_Enabler : MonoBehaviour {

    public bool isValid = false;
    public bool squadValid = false;
    public bool playerValid = false;

    GameObject player;
    public GameObject[] squad;

    Ray checkRay;
    RaycastHit hit;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        squad = GameObject.FindGameObjectsWithTag("Squad");

        // Will never move position so may as well set here then update direction as needed
        checkRay.origin = gameObject.transform.position;
    }

    public bool CheckValid () {
        isValid = false; // Must be reset to false every call otherwise will remain true after one swap

        checkPlayer();
        checkSquad();

        if (playerValid && squadValid) {
            isValid = true;
            //Debug.Log("isValid = " + isValid + " " + gameObject.name);
        }

        return isValid;
    }

    bool checkPlayer () {

        playerValid = false; // Must be reset to false every call otherwise will remain true after one swap

        // Move raycast towards player direction
        checkRay.direction = player.transform.position - gameObject.transform.position;

        Physics.Raycast(checkRay, out hit); // Raycast towards player for 50 units
		//Debug.DrawRay(checkRay.origin, checkRay.direction,Color.magenta,2);
        if (!hit.collider.CompareTag("Player")) // If you don't hit the player,
		{   
			playerValid = true;
			Debug.DrawLine(checkRay.origin, checkRay.direction,Color.magenta,2);  // it's a valid cover.
		}

        return playerValid;
    }

    bool checkSquad () {

        squadValid = false; // Must be reset to false every call otherwise will remain true after one swap

        bool squadInvalid = false;

        for (int i = 0; i < squad.Length; i++) {
            // Move raycast towards squad member [i]
            checkRay.direction = squad[i].transform.position - gameObject.transform.position;

            Physics.Raycast(checkRay, out hit, 50f);
			//Debug.DrawLine(checkRay.origin, checkRay.direction,Color.magenta,2);
            if (hit.collider.CompareTag("Squad"))
                squadInvalid = true;
        }

        if (!squadInvalid)
            squadValid = true;

        return squadValid;
    }
}