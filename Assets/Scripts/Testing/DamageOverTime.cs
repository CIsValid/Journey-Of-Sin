using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public int attackDamage;
    public float attackSpeed;
    private float attackSpeedCallable;
    private GameObject player;
    private PlayerManager playerManager;
    private Boolean timeToDamage;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        attackSpeedCallable = attackSpeed;
    }

    private void Update()
    {
        if (timeToDamage)
        {
            if (attackSpeedCallable > 0)
            {
                attackSpeedCallable -= Time.deltaTime;
            }
            else
            {
                playerManager.health -= attackDamage;
                attackSpeedCallable = attackSpeed;
            }
        }
        else
        {
            attackSpeedCallable = attackSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NullCheck(other);
            timeToDamage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timeToDamage = false;
    }

    private void NullCheck(Collider other)
    {
        if (!player)
        {
            player = other.gameObject;
        }

        if (player)
        {
            if (!playerManager)
            {
                playerManager = player.GetComponent<PlayerManager>();
            }
        }
    }
}
