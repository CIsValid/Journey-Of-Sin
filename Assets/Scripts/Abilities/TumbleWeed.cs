using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public GameObject explotionBuildUpVFX;
    public GameObject TumbleWeedExplotionVFX;
    public GameObject[] meshToDisable;

    public float timerForExplotion = 5f;

    public float timerToDestroyObject = 2f;

    public bool destroyObject;

    private Rigidbody rb;
    private SphereCollider sc;

    private void Start() {
        rb = transform.GetComponent<Rigidbody>();
        sc = transform.GetComponent<SphereCollider>();
        sc.enabled = false;
    }

    private void Update() {
        if(timerForExplotion > 0)
        {
            timerForExplotion -= Time.deltaTime;
        }
        else{
            // first we hide the build up Object
            explotionBuildUpVFX.SetActive(false);
            // Then we play Explotion Effect
            TumbleWeedExplotionVFX.SetActive(true);
            sc.enabled = true;

            foreach (var Objects in meshToDisable)
            {
                Objects.SetActive(false);
            }

            destroyObject = true;
        }

        if (destroyObject)
        {
            rb.velocity = new Vector3(0,0,0);

            if (timerToDestroyObject > 0)
            {
                timerToDestroyObject -= Time.deltaTime;      
            }
            else
            {
                Destroy(this.gameObject);
            }

            if (timerToDestroyObject < 1.5f)
            {
                sc.enabled = false;
            }   
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            explotionBuildUpVFX.SetActive(false);
            TumbleWeedExplotionVFX.SetActive(true);
                foreach (var Objects in meshToDisable)
                {
                    Objects.SetActive(false);
                }
            Destroy(other.gameObject);
            destroyObject = true;
        }
    }
}
