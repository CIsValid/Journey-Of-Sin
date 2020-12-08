using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public float timeBeforeExplotion = 4;
    public float timeBeforeDestruction = 2;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBeforeExplotion >= 0)
        {
            timeBeforeExplotion -= Time.deltaTime;

        }
        else
        {
            
            if (timeBeforeDestruction >= 0)
            {
                timeBeforeDestruction -= Time.deltaTime;
                meshRenderer.enabled = false;

            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
