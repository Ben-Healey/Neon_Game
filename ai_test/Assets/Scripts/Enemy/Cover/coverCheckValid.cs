using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coverCheckValid : MonoBehaviour {

    coverManager    manager;

	GameObject      player;
	RaycastHit      hit;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        manager = GetComponent<coverManager>();
	}

	void Update () {
		Physics.Raycast (this.transform.position, (player.transform.position - this.transform.position), out hit, Mathf.Infinity);
        if (!hit.collider.CompareTag("Player")) {
            if (manager.validCover.Contains(this.gameObject))
                manager.validCover.Add(this.gameObject);
        } else {
            if (manager.validCover.Contains(this.gameObject))
                manager.validCover.Remove(this.gameObject);
        }
	}
}