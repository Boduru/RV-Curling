using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTopBottomWall : MonoBehaviour
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
        b = new Vector3(transform.position.x, transform.position.y + side * maxDistance, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Lerp(a.y, b.y, timeElapsed / lerpDuration);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
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
