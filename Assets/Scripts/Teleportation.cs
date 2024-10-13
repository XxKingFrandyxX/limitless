using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that handles teleportation of the player to a specified destination
public class Teleportation : MonoBehaviour
{
    // References to the player's Transform and the destination Transform
    public Transform player, destination;

    // Reference to the player GameObject
    public GameObject playerg;
 
    // Method triggered when another object enters the trigger collider attached to this object
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "Player"
        if(other.CompareTag("Player"))
        {
            // Deactivate the player GameObject temporarily
            playerg.SetActive(false);

            // Set the player's position to the destination's position, teleporting them
            player.position = destination.position;

            // Reactivate the player GameObject after teleporting
            playerg.SetActive(true);
        }
    }
}

