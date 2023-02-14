using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    private int side=1;
    public float speed = 60;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float angle = side* speed * Time.deltaTime;
        if (transform.rotation.z >= 0.7)
        {
            side=-1;
        } else if (transform.rotation.z <= 0)
        {
            side = 1;
        }

        transform.Rotate(0,  0, angle);

    }
}
