using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Movement : MonoBehaviour
{
    public float XSpaces;
    public float speed;
    private Vector2 newPosition;
    private Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newPosition.x += XSpaces;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(newPosition, transform.position) <= 0.001f)
        {
            newPosition = previousPosition;
            previousPosition = transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}
