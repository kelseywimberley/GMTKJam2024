using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraMovement : MonoBehaviour
{
    public float speed = 0.001f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= new Vector3(0, speed, 0);
    }
}
