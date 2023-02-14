using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOverTime : MonoBehaviour
{
    Color colorStart = Color.red;
    Color colorEnd = Color.green;
    float duration = 3.0f;
    private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        // Change color over time
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, timeCount/duration);

        if (timeCount >= duration)
        {
            timeCount = 0;
            colorStart = colorEnd;
            colorEnd = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        }





    }
}
