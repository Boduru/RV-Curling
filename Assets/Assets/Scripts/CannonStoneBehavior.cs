using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStoneBehavior : MonoBehaviour
{
    // Time left to survive
    private float timeLeft = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            // Auto destroy
            Destroy(gameObject);
        }
    }
}
