using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotationVFX : MonoBehaviour
{
    Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f); //setting the rotation of the object to what it originally is
    void LateUpdate()
    {
    transform.rotation = spawnRot; //transforming the rotation each update to that rotation
    }
}
