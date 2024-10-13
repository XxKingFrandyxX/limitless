using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control a moving platform that follows waypoints
public class MovingPlatform : MonoBehaviour
{
    // Reference to the WaypointPath script containing the waypoints
    [SerializeField]
    private WaypointPath _wayPointPath;

    // Speed of the platform's movement
    [SerializeField]
    private float _speed;

    // Index of the current target waypoint
    private int _targetWaypointIndex;

    // References to the previous and current target waypoints
    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    // Total time needed to reach the current waypoint and the time elapsed since starting
    private float _timeToWaypoint;
    private float _elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the platform's movement by setting the next waypoint target
        TargetNextWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        // Update elapsed time by adding the time passed since the last frame
        _elapsedTime += Time.deltaTime;

        // Calculate the percentage of time elapsed to smoothly move between waypoints
        float elaspedPercentage = _elapsedTime / _timeToWaypoint;
        elaspedPercentage = Mathf.SmoothStep(0, 1, elaspedPercentage); // Smooth the interpolation for a smoother movement

        // Interpolate the platform's position and rotation between the previous and target waypoints
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elaspedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elaspedPercentage);

        // If the platform has reached the target waypoint, set the next waypoint as target
        if (elaspedPercentage >= 1)
        {
            TargetNextWayPoint();
        }
    }

    // Method to set the next waypoint as the new target
    private void TargetNextWayPoint()
    {
        // Set the current target waypoint as the previous waypoint
        _previousWaypoint = _wayPointPath.GetWaypoint(_targetWaypointIndex);

        // Update the target waypoint index to the next one
        _targetWaypointIndex = _wayPointPath.GetNextWaypointIndex(_targetWaypointIndex);

        // Get the Transform of the new target waypoint
        _targetWaypoint = _wayPointPath.GetWaypoint(_targetWaypointIndex);

        // Reset the elapsed time to start the interpolation from the beginning
        _elapsedTime = 0;

        // Calculate the distance to the new target waypoint and the time needed to reach it
        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed; // Time = Distance / Speed
    }

    // Event triggered when an object enters the platform's collider
    private void OnTriggerEnter(Collider other)
    {
        // Set the other object's parent to this platform, making it move with the platform
        other.transform.SetParent(transform);
    }

    // Event triggered when an object exits the platform's collider
    private void OnTriggerExit(Collider other)
    {
        // Remove the object from the platform's parent, so it no longer moves with the platform
        other.transform.SetParent(null); 
    }
}
