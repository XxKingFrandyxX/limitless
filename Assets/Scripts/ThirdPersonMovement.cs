using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle third-person movement mechanics
public class ThirdPersonMovement : MonoBehaviour
{
    // Public variables for the character controller and camera Transform
    public CharacterController controller;
    public Transform cam;

    // Movement and physics parameters
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundMask;

    // Private variables for smooth rotation and velocity tracking
    float turnSmoothVelocity;
    Vector3 velocity;
    bool isGrounded;

    // Transform used to check if the character is on the ground
    public Transform groundCheck;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground by casting a sphere at the groundCheck position
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        // If the player is grounded and currently falling, reset the y velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Capture input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If there is input, handle movement and rotation
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on input and camera angle
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
            // Smoothly rotate the character towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate the movement direction and apply it to the character controller
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Jumping mechanics: if grounded and Jump is pressed, calculate the jump velocity
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity over time
        velocity.y += gravity * Time.deltaTime;

        // Apply the velocity (including vertical) to the character controller
        controller.Move(velocity * Time.deltaTime);
        
        // Button to lock the cursor to the center of the screen
        if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // GUI elements for locking and confining the cursor
    void OnGUI()
    {
        // Button to lock the cursor
        if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Button to confine the cursor within the game window
        if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
