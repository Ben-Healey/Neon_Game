using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Find_Cover : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent;
    public List<GameObject> coverList = new List<GameObject>(); // All nearby covers
    public List<GameObject> validCover = new List<GameObject>(); // Covers that return as valid

	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void FixedUpdate () {
		for (int i = 0; i < coverList.Count; i++) {
            // Check if the cover is valid
            if (coverList[i].GetComponent<coverEnabler>().CheckValid()) {
                Debug.Log("Cover is valid");
                // Cover will need to be added to another list of valid covers, this list will be searched for closest and move to it.
                validCover.Add(coverList[i]);
            }
        }
        // Function checks all valid cover points to find the one closest to itself and sets that as its destination.
        agent.SetDestination(MoveToCover());
    }

    // Add the detected cover to the list of considered covers
    void OnTriggerEnter (Collider _collision) {
        if (_collision.gameObject.CompareTag("Cover"))
            coverList.Add(_collision.gameObject);
    }

    // Remove the out-of-range cover from the local list of covers
    void OnTriggerExit (Collider _collision) {
        if (_collision.gameObject.CompareTag("Cover"))
            coverList.Remove(_collision.gameObject);
    }

    Vector3 MoveToCover () {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        
        foreach(GameObject cover in validCover) {
            Vector3 directionToTarget = cover.transform.position - transform.position;
            float distSqrToTgt = directionToTarget.sqrMagnitude;
            if (distSqrToTgt < closestDistanceSqr) {
                closestDistanceSqr = distSqrToTgt;
                bestTarget = cover.transform;
            }
        }

        if (bestTarget == null) {
            bestTarget = transform;
            Debug.Log("bestTarget null -> no target");
        }

        return bestTarget.position;
    }
}
