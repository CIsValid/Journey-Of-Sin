﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(NavMeshAgent))]
public class GroundedPatroler : MonoBehaviour
{
    public float patrolSpeed = 5;
    public float chaseSpeed = 9f;
    public float patrolWaitTimer = 1f;
    public float chaseWaitTimer = 5f; 
    public float health = 100;

    public Transform[] patrolWayPoints;

    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private PlayerManager playerHealth; // to access player health

    private float chaseTimer;
    private float patrolTimer;

    private int wayPointIndex;
    private int treasureCheck;

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


        if(hasTreasure)
        {
            // If player steals hasTresure goes back to false
        }
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
}
