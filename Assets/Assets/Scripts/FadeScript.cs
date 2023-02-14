using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    private float transparence = 1;
    private bool fadeOut = true;
    private float step = 0.004f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transparence = Mathf.Clamp(transparence,0,1);
        if (fadeOut)
        {
            transparence -= step;
        }

        if (transparence < 0)
        {
            fadeOut = false;
        }

        GetComponent<CanvasGroup>().alpha = transparence;
        
    }
}
