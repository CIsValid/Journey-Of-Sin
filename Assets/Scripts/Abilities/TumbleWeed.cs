using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public float timeBeforeExplotion = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(this.gameObject);
            
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
