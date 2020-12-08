using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlightController : MonoBehaviour
{
    public Vector3 upwardsAcceleration;
    public Vector3 hoverGravity;
    public float walkSpeed = 2;
	public float runSpeed = 6;
	public float gravity = -12;
	[Range(0, 1)]
	public float airControlPercent;

	private float flapCooldown = 0.05f;
	private float flapCooldownCallable = 0.05f;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	Animator animator;
	Transform cameraT;
	CharacterController controller;

    public float timer = 5f;

	void Start()
	{
		//animator = GetComponent<Animator>();
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController>();
	}

    void Update()
    {

        // Ground Check
        if(controller.isGrounded)
        {
            timer = 5f;
            PlayerManager.instance.isFlying = false;
        }
        else{
            timer -= Time.deltaTime;
        }

        // input
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);

        Move(inputDir, running);

        Higher();

        Lower();

        controller.Move(hoverGravity * Time.deltaTime);
        
        if (flapCooldownCallable > 0) // Work in Progress
        {
	        flapCooldownCallable -= Time.deltaTime; // Work in Progress
        }
        
        // animator
        //float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }

	void Move(Vector2 inputDir, bool running)
	{
		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}

		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

	}

	float GetModifiedSmoothTime(float smoothTime)
	{
		if (controller.isGrounded)
		{
			return smoothTime;
		}

		if (airControlPercent == 0)
		{
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}
    void Higher()
    {
        if(timer >= 0)
        {
	        if(Input.GetKey(KeyCode.Space))
            {
                // flap with wings anim.SetBool("Flapping", true)
                if (flapCooldownCallable <= 0) // Work in Progress
                {
	                controller.Move(upwardsAcceleration * Time.deltaTime);

	                flapCooldownCallable = flapCooldown; // Work in Progress

                }

            }

        }
    }

    void Lower()
    {
        if(Input.GetKey(KeyCode.LeftControl)) 
        {
            // Stop flapping wings anim.SetBool("Flapping", false)
            controller.Move(-upwardsAcceleration * Time.deltaTime);

        }
        
    }
}
