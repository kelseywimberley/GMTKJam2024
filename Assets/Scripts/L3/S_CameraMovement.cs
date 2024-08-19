using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraMovement : MonoBehaviour
{
    public float speed = 0.003f;

    public GameObject fadeImage;

    void Start()
    {
        fadeImage.SetActive(true);
    }

    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}
