using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    public EditPathScript PathToFollow;

    public float speed;
    public int currentWayPointID = 0;

    private float reachDistance = 0.1f;
    private float prevAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Distance already done by the object towards the current waypoint
        float distanceDone = Vector3.Distance(PathToFollow.path_objs[currentWayPointID].position, transform.position);
        // Move object towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);

        // Previous way point ID
        int prevWayPointID = Mathf.Max(currentWayPointID - 1, 0);

        // If we are on the last waypoint, loop back to the first
        if (currentWayPointID == 0 && prevAngle != 0.0f)
        {
            prevWayPointID = PathToFollow.path_objs.Count - 1;
        }

        // Calculate the angle between the current waypoint and the previous waypoint
        float distanceAB = Vector3.Distance(PathToFollow.path_objs[prevWayPointID].position, PathToFollow.path_objs[currentWayPointID].position);
        float ratio = 1 - distanceDone / distanceAB;
        float zAngle = PathToFollow.path_objs[currentWayPointID].rotation.eulerAngles.z;

        if (currentWayPointID == 0 && prevAngle != 0.0f)
        {
            zAngle = 360;
        }

        float angle = Mathf.Lerp(prevAngle, zAngle, ratio);

        if (float.IsNaN(angle))
        {
            angle = 0.0f;
        }

        transform.rotation = Quaternion.Euler(0, 0, -angle);

        // Handle next waypoint run over and point 0 case
        if (distanceDone <= reachDistance)
        {
            prevAngle = PathToFollow.path_objs[currentWayPointID].rotation.eulerAngles.z;
            currentWayPointID++;
        
            if (currentWayPointID >= PathToFollow.path_objs.Count)
            {
                currentWayPointID = 0;
            }
        }
    }
}
