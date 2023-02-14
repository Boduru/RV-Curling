using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlade : MonoBehaviour
{
    public float nbSecondsWait;
    private float timeCountWait = 0.0f;

    public float maxRotation;
    private float timeCount = 0.0f;
    private int side = 1;

    private Quaternion a;
    private Quaternion b;

    // Start is called before the first frame update
    void Start()
    {
        a = transform.rotation;
        b = new Quaternion(transform.rotation.x, transform.rotation.y + maxRotation, transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        // float y = Mathf.Lerp(a.y, b.y, timeCount);
        // transform.rotation = new Quaternion(transform.rotation.x, y, transform.rotation.z, transform.rotation.w);

        if (timeCountWait < nbSecondsWait)
        {
            timeCountWait += Time.deltaTime;
        } else {
            timeCount += side * Time.deltaTime / maxRotation;
            transform.rotation = Quaternion.Slerp(a, b, timeCount);
            
            if (timeCount > 1 / maxRotation || timeCount < 0)
            {
                side *= -1;

                if (timeCount > 1 / maxRotation)
                {
                    timeCount = 1 / maxRotation;
                } else {
                    timeCount = 0;
                }
            }
        }
    }
}
