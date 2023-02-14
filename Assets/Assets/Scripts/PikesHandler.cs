using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikesHandler : MonoBehaviour
{
    public float yLimit; //0.26
    public float yScare; //0.02f
    public float scareSpeed; // 0.1f
    public float upSpeed; //0.3f
    public float downSpeed;
    public float maxUpTimer; //2.0f
    public float startDelay; //0.5f
    
    private float upTimer = 0.0f;
    private float yOrigin;
    private int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        yOrigin = transform.GetChild(0).transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Wait little time before doing anything
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        if (state == 0)
        {
            toggleChildrenCollider(false);
            MovePikesToScare();
        }
        else if (state == 1)
        {
            toggleChildrenCollider(true);
            MovePikesToLimit();
        }
        else if (state == 2)
        {
            upTimer = 0.0f;
        }
        else if (state == 3)
        {
            upTimer += Time.deltaTime;
        }
        else if (state == 4)
        {
            toggleChildrenCollider(false);
            MovePikesToBottom();
        }

        UpdateState();
    }

    private void MovePikesToScare()
    {
        // Move up all children
        foreach (Transform child in transform)
        {
            if (child.position.y < yScare)
            {
                child.position = new Vector3(child.position.x, child.position.y + scareSpeed * Time.deltaTime, child.position.z);
            }
        }
    }

    private void MovePikesToLimit()
    {
        // Move up all children
        foreach (Transform child in transform)
        {
            if (child.position.y < yLimit)
            {
                child.position = new Vector3(child.position.x, child.position.y + upSpeed * Time.deltaTime, child.position.z);
            }
        }
    }

    private void MovePikesToBottom()
    {
        // Move up all children
        foreach (Transform child in transform)
        {
            if (child.position.y > yOrigin)
            {
                child.position = new Vector3(child.position.x, child.position.y - downSpeed * Time.deltaTime, child.position.z);
            }
        }
    }

    private void UpdateState()
    {
        var childTransform = transform.GetChild(0).transform;

        if (state == 0)
        {
            if (childTransform.position.y >= yScare)
            {
                state = 1;
            }
        }
        else if (state == 1)
        {
            if (childTransform.position.y >= yLimit)
            {
                state = 2;
            }
        }
        else if (state == 2)
        {
            state = 3;
        }
        else if (state == 3)
        {
            if (upTimer >= maxUpTimer)
            {
                state = 4;
            }
        }
        else if (state == 4)
        {
            if (childTransform.position.y <= yOrigin)
            {
                state = 0;
            }
        }
    }

    private void toggleChildrenCollider(bool state)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshCollider>().enabled = state;
        }
    }
}
