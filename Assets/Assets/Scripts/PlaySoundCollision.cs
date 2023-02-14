using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundCollision : MonoBehaviour
{
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Ground") {
            Debug.Log(other.gameObject.tag);
            sound.Play();
        }
    }
}
