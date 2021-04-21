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
    private PlayerManager playerManager;
    
    public float viewDistance;
    
    [FormerlySerializedAs("rotSpeed")] public float returnSpeed;

    private Quaternion startRot;
    public float distToPlayer;

    public float attackDamage;

    public Boolean lookingAtPlayer;
    
    public List<Collider> TriggerList = new List<Collider>();

    private void Start()
    {
        startRot = transform.rotation;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (hasBeenDetected && target)
        {
            distToPlayer = Vector3.Distance(target.transform.position, transform.position);
            
            if (distToPlayer <= viewDistance)
            {
                transform.LookAt(target.transform.position);
                lookingAtPlayer = true;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, returnSpeed * Time.deltaTime);
                lookingAtPlayer = false;
            }
        }

        if (lookingAtPlayer && distToPlayer <= viewDistance && TriggerList.Count < 2)
        {
            playerManager.health -= attackDamage / 100;
            Debug.Log("Attacking");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            playerManager = other.gameObject.GetComponent<PlayerManager>();
            if (!hasBeenDetected)
            {
                audioSource.Play();
                hasBeenDetected = true;
            }
        }
        else
        {
            lookingAtPlayer = false;
            target = null;
        }
    }

    /*private void OnCollisionStay(Collision other)
    {
        //if the object is not already in the list
        if(!TriggerList.Contains(other))
        {
            //add the object to the list
            TriggerList.Add(other);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        //if the object is in the list
        if(TriggerList.Contains(other))
        {
            //remove it from the list
            TriggerList.Remove(other);
        }
 
    }*/
}
