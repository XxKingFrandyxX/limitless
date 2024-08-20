using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _wayPointPath;

    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        float elaspedPercentage = _elapsedTime / _timeToWaypoint;
        elaspedPercentage = Mathf.SmoothStep(0, 1, elaspedPercentage);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elaspedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elaspedPercentage);

        if (elaspedPercentage >= 1)
        {
            TargetNextWayPoint();
        }
    }

    private void TargetNextWayPoint()
    {
        _previousWaypoint = _wayPointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _wayPointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _wayPointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null); 
    }
}
