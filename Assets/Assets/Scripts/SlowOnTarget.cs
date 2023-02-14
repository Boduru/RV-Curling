using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnTarget : MonoBehaviour
{
    
    public CheckCollisionWithTarget checkCollisionWithTarget;
    private Rigidbody rigidBody;
    private float targetFriction = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (checkCollisionWithTarget.GetLevel() > 0)
        {
            rigidBody.velocity = rigidBody.velocity * targetFriction;
            Debug.Log(rigidBody.velocity);
        }
    }
}
