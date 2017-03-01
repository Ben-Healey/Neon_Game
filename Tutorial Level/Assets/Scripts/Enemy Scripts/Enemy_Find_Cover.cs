using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Find_Cover : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent;
    public List<GameObject> coverList = new List<GameObject>(); // All nearby covers
    public List<GameObject> validCover = new List<GameObject>(); // Covers that return as valid

    GameObject player;

	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
		for (int i = 0; i < coverList.Count; i++) {
            
            if (coverList[i].GetComponent<coverEnabler>().CheckValid()) // Check if the cover is valid
                
                if (!validCover.Contains(coverList[i])) // If it's not already in the valid list, add it
                    validCover.Add(coverList[i]);
             
            if (validCover.Contains(coverList[i]))                           // If it is already in the valid list...
                if (!coverList[i].GetComponent<coverEnabler>().CheckValid()) // But it's no longer valid...
                    validCover.Remove(coverList[i]);                         // Remove it
        }
        
       agent.SetDestination(MoveToCover());
        Debug.DrawLine(agent.transform.position, agent.destination);
    }

    // Add the detected cover to the list of considered covers
    void OnTriggerEnter (Collider _collision) {

        if (_collision.gameObject.CompareTag("Cover"))
            coverList.Add(_collision.gameObject);
    }

    // Remove the out-of-range cover from the local list of covers
    void OnTriggerExit (Collider _collision) {
        if (_collision.gameObject.CompareTag("Cover")) {

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
            Vector3 goForward = transform.position + Vector3.forward;
            bestTarget = player.transform;
            Debug.Log("No valid cover - moving forwards");
        }

        return bestTarget.position;
    }
}
