using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritRotation : MonoBehaviour
{
    public Transform targetRotation;

    private void Update()
    {
        transform.Rotate(targetRotation.rotation.x,targetRotation.rotation.y, transform.rotation.z);
    }
}
