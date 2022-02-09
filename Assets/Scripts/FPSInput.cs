using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private CharacterController charController;

    private float gravity = -9.81f;

    public float speed = 9.0f;

    private float jumpHeight = 3.0f;
    private float jumpTime = 1f;
    private float initialJumpVelocity;
    private float jumps = 0;

    private float yVelocity = 0;
    private float yVelocityWhenGrounded = -4.0f;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        float timeToApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * jumpHeight) / timeToApex;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Convert local to global coordinates 
        movement = transform.TransformDirection(movement);

        // Clamp magnitude for diagonal movement 
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        // determine how far to move on the XZ plane 
        movement *= speed;

        yVelocity += gravity * Time.deltaTime;
        
        if (charController.isGrounded && yVelocity < 0.0)
        {
            yVelocity = yVelocityWhenGrounded;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (charController.isGrounded)
            {
                yVelocity = initialJumpVelocity;
                jumps += 1;
            }
            else if (jumps > 0)
            {
                yVelocity = initialJumpVelocity;
                jumps = 0;
            }
        }

        movement.y = yVelocity;

        charController.Move(movement * Time.deltaTime);

    }
}
