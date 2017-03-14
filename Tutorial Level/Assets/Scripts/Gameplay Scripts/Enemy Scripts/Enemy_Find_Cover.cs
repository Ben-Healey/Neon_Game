using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Find_Cover : MonoBehaviour {

    public NavMeshAgent agent;
    public List<GameObject> coverList;  // All nearby covers
    public List<GameObject> validCover; // Covers that return as valid

    GameObject player;

    public bool idle = true; // Don't start until called for

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        coverList = new List<GameObject>();
        validCover = new List<GameObject>();
    }

    void FixedUpdate () {
		//Debug.Log (idle);
        if (!idle) {

            for (int i = 0; i < coverList.Count; i++) {

                if (coverList[i].GetComponent<Cover_Enabler>().CheckValid()) // Check if the cover is valid

                    if (!validCover.Contains(coverList[i])) // If it's not already in the valid list, add it
                        validCover.Add(coverList[i]);

                if (validCover.Contains(coverList[i]))                           // If it is already in the valid list...
                    if (!coverList[i].GetComponent<Cover_Enabler>().CheckValid()) // But it's no longer valid...
                        validCover.Remove(coverList[i]);                         // Remove it
            }

            agent.SetDestination(MoveToCover());
            Debug.DrawLine(agent.transform.position, agent.destination);
        }
    }

    // Add the detected cover to the list of considered covers
    void OnTriggerEnter (Collider _collision) {
       // Debug.Log("this is happen");

        if (_collision.gameObject.tag == "Covers")
        //{
            coverList.Add(_collision.gameObject);
            //Debug.Log("adding");
        //}
    }

    // Remove the out-of-range cover from the local list of covers
    void OnTriggerExit (Collider _collision) {
        if (_collision.gameObject.CompareTag("Covers")) {

            if (validCover.Contains(_collision.gameObject)) // If the coverpoint is also valid...
                validCover.Remove(_collision.gameObject);   // Then remove it from the valid choices when it goes out of range.

            coverList.Remove(_collision.gameObject);
        }
    }

    Vector3 MoveToCover () {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject cover in validCover) {
            Vector3 directionToTarget = cover.transform.position - transform.position;
            float distSqrToTgt = directionToTarget.sqrMagnitude;
            if (distSqrToTgt < closestDistanceSqr) {
                closestDistanceSqr = distSqrToTgt;
                bestTarget = cover.transform;
                Debug.DrawLine(cover.transform.position, bestTarget.position, Color.magenta);
            }
        }

        if (bestTarget == null) {
            bestTarget = player.transform;
            Debug.Log("No valid cover - moving toward player");
        }

        return bestTarget.position;
    }

    public void setIdle()
    {
        idle = false;
    }
}