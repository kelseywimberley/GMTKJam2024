using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LightMovement : MonoBehaviour
{
    private S_PlayerControlsLevelOne player;

    private bool moving;
    private float timer;
    public float waitTime = 1.5f;

    private Vector3 newPosition;
    private bool left;
    public float speed = 0.01f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<S_PlayerControlsLevelOne>();
        moving = false;
        timer = 0.0f;
        newPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!player.IsPaused())
        {
            if (moving)
            {
                if (Vector3.Distance(transform.position, newPosition) < 0.1f)
                {
                    moving = false;

                    timer = 0.0f;
                }
                else
                {
                    if (left)
                    {
                        transform.position -= new Vector3(speed, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(speed, 0, 0);
                    }
                }
            }
            else
            {
                if (timer < waitTime)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    moving = true;

                    newPosition.x = Random.Range(-7, 7);
                    if (newPosition.x < transform.position.x)
                    {
                        left = true;
                    }
                    else
                    {
                        left = false;
                    }
                }
            }
        }
    }
}
