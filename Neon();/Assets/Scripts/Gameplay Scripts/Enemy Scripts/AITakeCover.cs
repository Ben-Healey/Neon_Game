using System.Collections;
using UnityEngine;

// https://github.com/hkalexling/Unity-3D-Cover-System

public class AITakeCover : MonoBehaviour
{

    public GameObject[] cover;

    public GameObject player;
    public GameObject[] enemy;
    public GameObject[] squad;

    public float detectAngle = 120f;
    public float detectDistance = 20f;
    public float sideDetectDistance = 5f;
    public bool notice;

    public bool hasNoticePlayer;
    public bool hasNoticeSquad;

    public int coverNum = -1;

    public bool inCover;

    public int shootCooldown = 10;
    public int shootDelay = 10;

    public GameObject projectile;
    public Transform spawnPoint;

    public UnityEngine.AI.NavMeshAgent nav;

    Animator anim;
    float vSpeed = 0;

    // Use this for initialization
    void Start()
    {
        nav = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        cover = GameObject.FindGameObjectsWithTag("Coverpoints");
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        squad = GameObject.FindGameObjectsWithTag("Squad");

        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Enemy")
        {
            LookForPlayer();
            LookForSquad();

            if (notice)
            {
                TakeCover();
                detectDistance = 1000f;
                sideDetectDistance = 1000f;
            }

            if (coverNum >= 0)
            {
                nav.SetDestination(cover[coverNum].transform.position);
                Debug.DrawLine(transform.position, cover[coverNum].transform.position);

                if ((Vector3.Distance(gameObject.transform.position, cover[coverNum].transform.position)) > 1)
                {
                    this.anim.SetFloat("VSpeed", (vSpeed += 0.1f));
                }
                else
                    this.anim.SetFloat("VSpeed", (vSpeed = 0));
            }

            if (inCover)
            {
                FaceTarget(gameObject);
                Shoot();
            }
        }

        if (gameObject.tag == "Squad")
        {
            LookForEnemy();

            if (notice)
            {
                TakeCover();
                detectDistance = 1000f;
                sideDetectDistance = 1000f;
            }

            if (coverNum >= 0)
            {
                nav.SetDestination(cover[coverNum].transform.position);
                Debug.DrawLine(transform.position, cover[coverNum].transform.position);

                if ((Vector3.Distance(gameObject.transform.position, cover[coverNum].transform.position)) > 1)
                {
                    this.anim.SetFloat("VSpeed", (vSpeed += 0.1f));
                }
                else
                    this.anim.SetFloat("VSpeed", (vSpeed = 0));
            }

            if (inCover)
            {
                FaceTarget(gameObject);
            }
        }
    }

    //Find the closest, empty and safe cover
    void TakeCover()
    {
        float[] coverDistance = new float[cover.Length];

        for (int i = 0; i < cover.Length; i++)
        {
            coverDistance[i] = Vector3.Distance(this.transform.position, cover[i].transform.position);
        }

        float[] sortedDistance = (float[])coverDistance.Clone();
        System.Array.Sort(sortedDistance);
        for (int i = 0; i < cover.Length; i++)
        {
            int j = System.Array.IndexOf(coverDistance, sortedDistance[i]);
            CoverScript coverscript = cover[j].GetComponent<CoverScript>();

            if (gameObject.tag == "Squad")
            {
                if (coverscript.enemySafe && (!coverscript.full || coverscript.usedBy == gameObject))
                {
                    coverNum = j;
                    break;
                }
            }

            if(gameObject.tag=="Enemy")
            {
                if(coverscript.playerSafe && coverscript.squadSafe && (!coverscript.full || coverscript.usedBy == gameObject))
                {
                    coverNum = j;
                    break;
                }
            }
        }
    }

    void LookForPlayer()
    {
        Vector3 playerVector = player.transform.position - transform.position;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if ((((Mathf.Abs((int)Vector3.Angle(this.transform.forward, playerVector)) < detectAngle / 2f) && (distance < detectDistance)) || (distance < sideDetectDistance))
            && FacingPlayer())
        {
            notice = true;
        }
    }

    void LookForSquad()
    {
        Vector3[] squadVector = new Vector3[squad.Length];
        float[] distance = new float[squad.Length];

        for (int i = 0; i < squad.Length; i++)
        {
            squadVector[i] = squad[i].transform.position - transform.position;
            distance[i] = Vector3.Distance(this.transform.position, squad[i].transform.position);


            if ((((Mathf.Abs((int)Vector3.Angle(this.transform.forward, squadVector[i])) < detectAngle / 2f) && (distance[i] < detectDistance)) || (distance[i] < sideDetectDistance))
            && FacingSquad(squadVector))
            {
               notice = true;
            }
        }
    }

    void LookForEnemy()
    {
        Vector3[] enemyVector = new Vector3[enemy.Length];
        float[] distance = new float[enemy.Length];

        for (int i = 0; i < enemy.Length; i++)
        {
            enemyVector[i] = enemy[i].transform.position - transform.position;
            distance[i] = Vector3.Distance(this.transform.position, enemy[i].transform.position);


            if ((((Mathf.Abs((int)Vector3.Angle(this.transform.forward, enemyVector[i])) < detectAngle / 2f) && (distance[i] < detectDistance)) || (distance[i] < sideDetectDistance))
            && FacingEnemy(enemyVector[i]))
            {
                notice = true;
            }
        }
    }

    bool FacingPlayer()
    {
        RaycastHit hit;
        Vector3 playerVector = player.transform.position - transform.position;
        return (Physics.Raycast(transform.position, playerVector, out hit)) && (hit.transform.gameObject.tag == "Player");
    }

    bool FacingSquad(Vector3[] inVectors)
    {
        RaycastHit hit;
        //Vector3[] squadVector = inVectors;

        bool isFacingSquad = false;

        for (int i = 0; i < squad.Length; i++)
        {
            Physics.Raycast(transform.position, (inVectors[i] - transform.position), out hit);
            if (hit.transform.gameObject.tag == "Squad")
                isFacingSquad = true;
        }

        return isFacingSquad;
    }

    bool FacingEnemy(Vector3 enemyVec)
    {
        RaycastHit hit;
        //Vector3[] enemyVector = inVectors;

        bool isFacingEnemy = false;

        //for (int i = 0; i < enemy.Length; i++)
        //{
            if(Physics.Raycast(transform.position, (enemyVec - transform.position), out hit))
                if (hit.transform.tag == "Enemy")
                    isFacingEnemy = true;
        //}

        return isFacingEnemy;
    }

    void FaceTarget(GameObject who)
    {
        if (who.tag == "Enemy")
        {
            Vector3 closest = Vector3.forward;

            float playerDistance = Vector3.Distance(this.transform.position, player.transform.position);

            float[] distance = new float[squad.Length];

            for(int i = 0; i < squad.Length; i++)
            {
                distance[i] = Vector3.Distance(this.transform.position, squad[i].transform.position);
            }

            float[] sortedDistance = (float[])distance.Clone();
            System.Array.Sort(sortedDistance);
            int j = System.Array.IndexOf(distance, sortedDistance[0]);

            if (sortedDistance[0] > playerDistance)
                closest = player.transform.position;
            else
                closest = squad[j].transform.position;
            
            Vector3 lookPosition = closest - transform.position;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
        }

        if(who.tag=="Squad")
        {
            Vector3 closest = Vector3.forward;

            float[] distance = new float[enemy.Length];

            for (int i = 0; i < enemy.Length; i++)
            {
                distance[i] = Vector3.Distance(this.transform.position, enemy[i].transform.position);
            }

            float[] sortedDistance = (float[])distance.Clone();
            System.Array.Sort(sortedDistance);
            int j = System.Array.IndexOf(distance, sortedDistance[0]);

            closest = enemy[j].transform.position;

            Vector3 lookPosition = closest - transform.position;
            lookPosition.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
        }
    }

    void Shoot()
    {
        GameObject shot;
        shot = (GameObject)Instantiate(projectile, spawnPoint.position, Quaternion.identity) as GameObject;
        shot.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }
}
