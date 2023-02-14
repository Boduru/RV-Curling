using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Float back and forth
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * range, transform.position.z);
    }
}
