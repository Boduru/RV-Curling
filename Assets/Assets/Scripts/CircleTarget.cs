using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTarget : MonoBehaviour
{
    public Material successMaterial;
    public AudioSource successSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stone")
        {
            // Change material to green
            GetComponent<Renderer>().material = successMaterial;
            // Make the cannon able to fire
            GameObject cannon = GameObject.FindGameObjectWithTag("Cannon");
            cannon.GetComponent<CannonBehavior>().SetCanFire(true);
            // Play sound
            successSound.volume = 0.5f;
            successSound.Play();
        }
    }
}
