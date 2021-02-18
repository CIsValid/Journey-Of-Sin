using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Camera mCamera;

    private void Start()
    {
        mCamera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = mCamera.transform.rotation;
    }
}
