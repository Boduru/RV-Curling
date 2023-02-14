using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CannonBehavior cb = GameObject.Find("Cannon").GetComponent<CannonBehavior>();
        cb.ChangeYAngle(transform.rotation.eulerAngles.x);
        // Debug.Log(transform.rotation.eulerAngles.x);
    }
}
