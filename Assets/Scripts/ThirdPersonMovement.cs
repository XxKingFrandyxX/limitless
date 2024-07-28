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

    void Inputs()
    {
        forwardDirection = Input.GetAxis("Vertical");
        sideDirection = Input.GetAxis("Horizontal");
    }

    void Start()
    {
        if (cam -- null)
            {
                cam = Camera.main.transform;
            }
    }
}
