using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyMoveToCover : MonoBehaviour {

    coverManager coverList;

    NavMeshAgent    agent;
    GameObject      player;
    Transform       destinationCover;

    void Start () {
        coverList = GetComponent<coverManager>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        agent.destination = destinationCover.position;
    }
}