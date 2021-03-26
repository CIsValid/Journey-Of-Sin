using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritLocation : MonoBehaviour
{
    public Transform targetLoc;

    private void Update()
    {
        transform.position = new Vector3(targetLoc.position.x, targetLoc.position.y, transform.position.z);
    }
}
