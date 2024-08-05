using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWTrigger : MonoBehaviour
{
    public Transform destination;

    public void Teleport(Transform target)
    {
        target.position = destination.position;
        target.rotation = destination.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Teleport(other.transform);
        if (other.tag == "player")
        {
            FindObjectOfType<Third Person Camera>().RotateBehindPlayer();
        }
    }

    public void RotateBehindPlayer()
    {
        lookAngle = target.rotation.eulerAngles.y;
    }

    void Update()
    {
        //HandleRotation();
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateBehindPlayer();
        }
    }
}
