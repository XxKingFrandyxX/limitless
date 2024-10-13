using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that provides functionality to manage and retrieve waypoints for a moving object
public class WaypointPath : MonoBehaviour
{
    // Method to get a waypoint by index
    public Transform GetWaypoint(int waypointIndex)
    {
        // Return the child Transform at the specified index
        return transform.GetChild(waypointIndex);
    }

    // Method to get the index of the next waypoint in the path
    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        // Calculate the index for the next waypoint
        int NextWaypointIndex = currentWaypointIndex + 1;

        // If the next index is equal to the number of children, loop back to the first waypoint
        if (NextWaypointIndex == transform.childCount)
        {
            NextWaypointIndex = 0;
        }

        // Return the index of the next waypoint
        return NextWaypointIndex;
    }
}

