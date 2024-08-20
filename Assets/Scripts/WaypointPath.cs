using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int NextWaypointIndex = currentWaypointIndex + 1;

        if (NextWaypointIndex == transform.childCount)
        {
            NextWaypointIndex = 0;
        }

        return NextWaypointIndex;
    }
}
