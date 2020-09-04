using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlightController : MonoBehaviour
{
    public CharacterController controller;
    Animator anim;
    public float speed = 8.0f;
    public float rotationSpeed = 100f;

    public Vector3 hoverGravity;

    // Start is called before the first frame update
    void Start()
    {
        // anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            PlayerManager.instance.isFlying = false;
        }

        

        if(Input.GetKey(KeyCode.Space))
        {
            // flap with wings anim.SetBool("Flapping", true)
            transform.Translate(0,0.03f,0);
        }
        else
        {
            // Stop flapping wings anim.SetBool("Flapping", false)
        }
        
        controller.Move(hoverGravity * Time.deltaTime);

    }
}
