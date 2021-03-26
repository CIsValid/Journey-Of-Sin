using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InheritLocation : MonoBehaviour
{
    [FormerlySerializedAs("targetLoc")] public Transform targetRotLoc;
    private VoiceLineDetectionEnemy vlde;

    private void Start()
    {
        vlde = GetComponent<VoiceLineDetectionEnemy>();
    }

    private void Update()
    {
        transform.position = new Vector3(targetRotLoc.position.x, transform.position.y, targetRotLoc.position.z);
        
        if (!vlde.lookingAtPlayer)
        {
            transform.rotation = targetRotLoc.rotation;

        }
    }
}
