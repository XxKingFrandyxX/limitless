using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float moveSpeed;
    public GameObject platform;
    public Transform[] points;
    public int pointSelection;
    Transform currentPoint;

    private void Start()
    {
        currentPoint = points[pointSelection];
    }

    private void MovePlatform()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position,currentPoint.position, Time.deltaTime * moveSpeed);
    }

    //private void Update()
    //{
        //MovePlatform();
    //}

    private void ChangePoint()
    {
        pointSelection++;
        if (pointSelection == points.Length)
        {
            pointSelection = 0;
        }
        currentPoint = points[pointSelection];
    }

    void Update()
    {
        MovePlatform();

        if (platform.transform.position == currentPoint.position)
        {
            ChangePoint();
        }
    }
}
