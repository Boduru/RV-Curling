using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLimitRespawnController : MonoBehaviour
{
    public float yLimit;
    public float initRotSpeed = 30;
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yLimit)
        {
            // Respawn at spawn point
            transform.position = respawnPoint.position;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            // Animate the respawn
            SpawnSpinAnimate();
        }
    }

    void SpawnSpinAnimate()
    {
        float r = Random.Range(1, 4);
        float side = Random.Range(-1, 1);

        if (side == 0)
        {
            side = 1;
        }

        GetComponent<Rigidbody>().AddRelativeTorque(0, r * side * initRotSpeed, 0);
    }
}
