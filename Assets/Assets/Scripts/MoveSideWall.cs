using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideWall : MonoBehaviour
{
    public int side;
    public float maxDistance;
    public float lerpDuration;
    private float timeElapsed;

    private Vector3 a;
    private Vector3 b;

    // Start is called before the first frame update
    void Start()
    {
        a = transform.position;
        b = new Vector3(transform.position.x + side * maxDistance, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Lerp(a.x, b.x, timeElapsed / lerpDuration);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        timeElapsed += side * Time.deltaTime;

        if (timeElapsed > lerpDuration || timeElapsed < 0)
        {
            side *= -1;

            if (timeElapsed > lerpDuration)
                {
                    timeElapsed = lerpDuration;
                } else {
                    timeElapsed = 0;
                }
        }
    }
}
