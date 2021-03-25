using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class VoiceLineDetectionEnemy : MonoBehaviour
{
    private AudioSource audioSource;

    private Boolean hasBeenDetected;

    private GameObject target;
    
    public float viewDistance;
    
    [FormerlySerializedAs("rotSpeed")] public float returnSpeed;

    private Quaternion startRot;
    
    private void Start()
    {
        startRot = transform.rotation;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (hasBeenDetected && target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) <= viewDistance)
            {
                transform.rotation = Quaternion.LookRotation(target.transform.position);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, returnSpeed * Time.deltaTime);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            if (!hasBeenDetected)
            {
                audioSource.Play();
                hasBeenDetected = true;
            }

        }
    }
}
