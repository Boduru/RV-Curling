using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionWithTarget : MonoBehaviour
{
    public GameObject innerTarget;
    public GameObject middleTarget;
    public GameObject outerTarget;
    private int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        level = 0;

        if (PointInCircle(transform.position, outerTarget.transform.position, 3.0f))
        {
            level = 3;
        }

        if (PointInCircle(transform.position, middleTarget.transform.position, 1.8f))
        {
            level = 2;
        }

        if (PointInCircle(transform.position, innerTarget.transform.position, 1f))
        {
            level = 1;
        }

        Debug.Log("Level: " + level);
    }

    bool PointInCircle(Vector3 point, Vector3 center, float radius)
    {
        float dist = Mathf.Abs(point.z - center.z);
        return dist < radius;
    }

    public int GetLevel()
    {
        return level;
    }
}
