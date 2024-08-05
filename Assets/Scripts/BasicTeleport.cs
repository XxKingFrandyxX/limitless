using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleport : MonoBehaviour
{
    public Transform teleportLocation;
    public Transform targetToTeleport;

    public void Teleport()
    {
        targetToTeleport.position = teleportLocation.position;
        targetToTeleport.rotation = teleportLocation.rotation;

        Rigidbody targetRB = targetToTeleport.GetComponent<Rigidbody>();
        if (targetRB != null)
        {
            targetRB.velocity = Vector3.zero;
            targetRB.angularVelocity = Vector3.zero;
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Teleport();
        }

    }
}
