using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(NavMeshAgent))]
public class DistractionEnemyJungle : MonoBehaviour
{
    public float patrolSpeed = 5;
    public float chaseSpeed = 9f;
    public float patrolWaitTimer = 1f;
    public float chaseWaitTimer = 5f; 
    public float health = 100;
    public float attentionRange;

    public Transform[] patrolWayPoints;

    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private PlayerManager playerHealth; // to access player health

    private float chaseTimer;
    private float patrolTimer;

    private int wayPointIndex;
    private int treasureCheck;

    public bool chasingPlayer;
    public bool hasBeenRobbed;
    public bool hasTreasure = false;

    // private Loot treasure; (a list of loot you're able to get when stealing)


    private void Awake()
    {
        enemySight = GetComponent<EnemySight>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerManager>();
        treasureCheck = Random.Range(0, 10);   
    }

    private void Start()
    {
        TreasureChecker();
    }

    private void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= attentionRange && !playerHealth.isCamoflaged)
        {
            chasingPlayer = true;
        }
        else
        {
            chasingPlayer = false;
        }

        switch (chasingPlayer)
        {
            case true:

            ChaseState();

            Debug.Log("Chasing The Player");
            break;

            case false:
            
            PatrolState();

            Debug.Log("Patroling State");
            break;
        }

        if(hasTreasure)
        {
            // If player steals hasTresure goes back to false
        }
    }

    void PatrolState()
    {
        nav.speed = patrolSpeed;

        if(!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            if(patrolWayPoints.Length == 0) return;

            nav.destination = patrolWayPoints[wayPointIndex].position;

            wayPointIndex = (wayPointIndex + 1) % patrolWayPoints.Length;
        }

    }

    void ChaseState()
    {
        nav.speed = chaseSpeed;
        nav.destination = player.position;
    }

    void InvestiagtionState()
    {
        // Here we put the logic of the investigation
    }

    void TreasureChecker()
    {

        switch (treasureCheck)
        {
            case 2:

                hasTreasure = true;
                Debug.Log("2"); // Give Enemy Treasure

                break;

            case 6:

                hasTreasure = true;
                Debug.Log("6"); // Give Enemy Treasure

                break;

            case 8:

                hasTreasure = true;
                Debug.Log("8"); // Give Enemy Treasure

                break;
        }
    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position, attentionRange);
    }
}
