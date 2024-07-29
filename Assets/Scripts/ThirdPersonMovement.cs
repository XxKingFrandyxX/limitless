using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    float forwardDirection;
    float sideDirection;
    public Transform cam;
    Vector3 camForward;
    public float rotationSpeed = 180;
    Vector3 move;
    CharacterController cc;
    public float moveSpeed = 4;
    public float jumpSpeed = 10.0f;
    public float gravityMultiplier = 3;
    float verticalVelocity = 0;

    void Inputs()
    {
        forwardDirection = Input.GetAxis("Vertical");
        sideDirection = Input.GetAxis("Horizontal");
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();

        if (cam == null)
            {
                cam = Camera.main.transform;
            }
    }

    void Rotation()
    {
        camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1).normalized);
        move = forwardDirection * camForward + sideDirection * cam.right;

        move.Normalize();
        move = transform.InverseTransformDirection(move);

        float turnAmout = Mathf.Atan2(move.x, move.z);
        transform.Rotate(0, turnAmout * rotationSpeed * Time.deltaTime, 0);
    }

    void Movement()    
    {
        Vector3 direction = transform.forward * move.z * moveSpeed;

        if (cc.isGrounded)
        {
            verticalVelocity = 0;
        }
        verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }
        direction.y = verticalVelocity;

        cc.Move(direction * Time.deltaTime);
    }
}
