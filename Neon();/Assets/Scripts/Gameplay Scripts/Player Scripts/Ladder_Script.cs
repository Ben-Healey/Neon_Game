using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Script : MonoBehaviour
{
    bool canClimb = false;
    GameObject player;
    Rigidbody rb;
    playerMovement player_move;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        player_move = player.GetComponent<playerMovement>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_move.enabled = false;
            Debug.Log("Player in ladder");
            canClimb = true;
            //if(Input.GetKeyDown(KeyCode.W))
            //{
            //    //Debug.Log("SHOULD GO UP!");
            //    //other.transform.Translate(Vector3(0,1,0) *  Time.deltaTime);
            //}
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canClimb = false;
            player_move.enabled = true;
        }
    }

    void Update()
    {
        if(canClimb == true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                //Debug.Log("BUTTON PRESS");
                //rb.AddForce(Vector3.up * 200);
                player.transform.Translate(Vector3.up * Time.deltaTime);
               
            }
            if(Input.GetKey(KeyCode.S))
            {
                //rb.AddForce(Vector3.down * 200);
                player.transform.Translate(Vector3.down * 1);
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                player.transform.Translate(Vector3.left * 1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                player.transform.Translate(Vector3.right * 1);
            }
        }

    }

}
