using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coverEnabler : MonoBehaviour {

    public bool isValid = false;
    public bool squadValid = false;
    public bool playerValid = false;

    GameObject player;
    GameObject[] squad;

    Ray checkRay;
    RaycastHit hit;
    
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        squad = GameObject.FindGameObjectsWithTag("Squad");

        // Will never move position so may as well set here then update direction as needed
        checkRay.origin = gameObject.transform.position;
	}

    public bool CheckValid () {
        checkPlayer();
        checkSquad();

        if(playerValid && squadValid) {
            Debug.Log("playerValid && squadValid passed");
            isValid = true;
        }

        Debug.Log("isValid = " + isValid);
        return isValid;
    }

    bool checkPlayer () {
        // Move raycast towards player direction
        checkRay.direction = player.transform.position - gameObject.transform.position;

        Physics.Raycast(checkRay, out hit, 50f); // Raycast towards player for 50 units

        if (!hit.collider.CompareTag("Player")) // If you don't hit the player,
            playerValid = true;                 // it's a valid cover.

        Debug.Log("playerValid = " + playerValid);
        return playerValid;
    }

    bool checkSquad () {
        //for(int i = 0; i < squad.Length; i++) {
        //    if(squad[i] == null)
        //        squad[i].
        //}

        bool looping = true;
        bool squadInvalid = false;

        for (int i = 0; i < squad.Length; i++) {
            while (looping) {
                // Move raycast towards squad member [i]
                checkRay.direction = squad[i].transform.position - gameObject.transform.position;

                Physics.Raycast(checkRay, out hit, 50f);
                if (hit.collider.CompareTag("Squad")) {
                    looping = false;
                    Debug.Log("looping should be false = " + looping);
                    squadInvalid = true;
                }
            }
        }

        if (!squadInvalid)
            squadValid = true;

        Debug.Log("squadValid = " + squadValid);
        return squadValid;
    }
}
