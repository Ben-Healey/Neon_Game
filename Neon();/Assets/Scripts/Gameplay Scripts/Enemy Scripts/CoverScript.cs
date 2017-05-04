using UnityEngine;
using System.Collections;

// https://github.com/hkalexling/Unity-3D-Cover-System

public class CoverScript : MonoBehaviour {

	public GameObject player;
    public GameObject[] squad;
    public GameObject[] enemy;

    public float maxLength = 100f;

	public bool playerSafe = false;
    public bool squadSafe = false;
    public bool enemySafe = false;

    public bool squadNotSafe = false;
    public bool enemyNotSafe = false;

	public bool full;
    public GameObject usedBy;

    static int squadLayer = 15;
    static int enemyLayer = 16;

    int enemyMask = ~(1 << enemyLayer);
    int squadMask = ~(1 << squadLayer);

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        squad = GameObject.FindGameObjectsWithTag("Squad");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, (player.transform.position - transform.position), out hit, maxLength, enemyMask)) {
			if (hit.transform.gameObject.tag == "Player"){
				playerSafe = false;
			}
			else{
				playerSafe = true;
			}
		}

        for (int i = 0; i < squad.Length; i++)
        {
            if(Physics.Raycast (transform.position, (squad[i].transform.position - transform.position), out hit, maxLength, enemyMask)) {
                if (hit.transform.gameObject.tag == "Squad")
                    squadNotSafe = true;
            }
        }

        if (squadNotSafe)
        {
            squadSafe = false;
            squadNotSafe = false;
        }
        else
            squadSafe = true;

        for (int i = 0; i < enemy.Length; i++)
        {
            if (Physics.Raycast(transform.position, (enemy[i].transform.position - transform.position), out hit, maxLength, squadMask))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                    enemyNotSafe = true;
            }
        }

        if (enemyNotSafe)
        {
            enemySafe = false;
            enemyNotSafe = false;
        }
        else
            enemySafe = true;
    }

	void OnTriggerEnter(Collider other){
		full = true;
        usedBy = other.gameObject;
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Squad") {
			AITakeCover aiTakeCover = other.gameObject.GetComponent<AITakeCover>();
			aiTakeCover.inCover = true;
		}
	}

	void OnTriggerExit(Collider other){
		full = false;
        usedBy = null;
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Squad") {
			AITakeCover aiTakeCover = other.gameObject.GetComponent<AITakeCover>();
			aiTakeCover.inCover = false;
		}
	}
}
