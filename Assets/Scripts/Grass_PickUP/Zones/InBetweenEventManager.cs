using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBetweenEventManager : MonoBehaviour
{
    public PlayerManager _playerManager;
    public GameObject[] gateRotOBject;
    public int howManyFlamesToCollect;
    public int flamesCollected;
    
    public float firstDoorRotAmount;
    public float secondDoorRotAmount;

    private Quaternion firstGateRotation;
    private Quaternion secondGateRotation;
    public float rotSpeed;

    private void Start()
    {
        firstGateRotation = Quaternion.Euler(0,firstDoorRotAmount,0);
        secondGateRotation = Quaternion.Euler(0,secondDoorRotAmount,0);
    }

    // Update is called once per frame
    void Update()
    {
        flamesCollected = _playerManager.collectedFlames;

        switch (flamesCollected == howManyFlamesToCollect)
        { 
            case true:
                
                if (gateRotOBject != null)
                {
                    gateRotOBject[0].transform.localRotation = Quaternion.Slerp(
                        gateRotOBject[0].transform.localRotation, firstGateRotation, rotSpeed * Time.deltaTime);
                    gateRotOBject[1].transform.localRotation = Quaternion.Slerp(
                        gateRotOBject[1].transform.localRotation, secondGateRotation, rotSpeed * Time.deltaTime);
                }

                break;
        }

    }
}
