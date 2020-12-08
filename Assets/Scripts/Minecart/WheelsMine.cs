using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class WheelsMine : MonoBehaviour
{
    private GameObject minecart;
    private Animator animator;
    private PathFollower pathFollower;

    private void Start()
    {
        if (!minecart)
        {
            minecart = this.transform.root.gameObject;
        }
        if (!animator)
        {
            animator = this.GetComponent<Animator>();
        }

        if (!pathFollower && minecart)
        {
            pathFollower = minecart.GetComponent<PathFollower>();
        }
    }

    private void Update()
    {
        animator.speed = pathFollower.speed;
        
        if (pathFollower.isRiding && !pathFollower.completedRide)
        {
            animator.SetBool("isMoving", true);
            Debug.Log("isPlaying");
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
