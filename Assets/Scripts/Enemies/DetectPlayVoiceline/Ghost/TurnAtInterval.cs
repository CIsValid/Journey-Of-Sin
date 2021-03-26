using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAtInterval : MonoBehaviour
{

    public float intervalTimer = 2f;
    public float rotSpeed = 2f;
    private float intervalTimerCached = 2f;
    public Boolean hasSpun;
    public Quaternion newRot;
    public Boolean hasIncreased;
    public float yRotationValue;
    private float spinTimer;


    private void Start()
    {
        intervalTimerCached = intervalTimer;
        newRot = transform.rotation;
    }

    void Update()
    {
        if (intervalTimer > 0)
        {
            intervalTimer -= Time.deltaTime;
            hasSpun = false;
            spinTimer = 1f;
            if (!hasIncreased)
            {
                yRotationValue += 180f;
                hasIncreased = true;
            }
        }
        else
        {
            newRot = Quaternion.Euler(0,-yRotationValue,0);
            transform.localRotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed * Time.deltaTime);
            
            if (spinTimer > 0)
            {
                spinTimer -= Time.deltaTime;
            }
            else
            {
                hasSpun = true;
            }

        }

        if (hasSpun)
        {
            intervalTimer = intervalTimerCached;
            hasIncreased = false;
        }

        if (yRotationValue >= 360)
        {
            yRotationValue = 0;
        }

    }
}
