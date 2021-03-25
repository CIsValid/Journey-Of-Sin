using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public float spinSpeed = 56f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,spinSpeed * Time.deltaTime,0);
    }
}
