using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControlsLevelOne : MonoBehaviour
{
    private bool paused;

    private Rigidbody2D rb;
    public float movementSpeed = 0.1f;
    public float maxSpeed = 1.5f;

    private bool bigEnough = false;
    public float scaleSpeed = 0.1f;

    void Start()
    {
        paused = false;
        rb = GetComponent<Rigidbody2D>();
        bigEnough = false;
    }

    void Update()
    {
        if (bigEnough)
        {

        }
        else if (paused)
        {

        }
        else
        {
            Movement();
        }
    }

    public void Movement()
    {
        //if (Input.GetButton("Up") && !Input.GetButton("Down"))
        //{
        //    rb.velocity += new Vector2(0, movementSpeed);
        //}
        //if (Input.GetButton("Down") && !Input.GetButton("Up"))
        //{
        //    rb.velocity += new Vector2(0, -movementSpeed);
        //}

        //if (Input.GetButton("Left") && !Input.GetButton("Right"))
        //{
        //    rb.velocity += new Vector2(-movementSpeed, 0);
        //}
        //if (Input.GetButton("Right") && !Input.GetButton("Left"))
        //{
        //    rb.velocity += new Vector2(movementSpeed, 0);
        //}


        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector2(0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector2(0, -movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector2(-movementSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector2(movementSpeed, 0);
        }

        rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxSpeed), Mathf.Min(rb.velocity.y, maxSpeed));
        rb.velocity = new Vector2(Mathf.Max(rb.velocity.x, -maxSpeed), Mathf.Max(rb.velocity.y, -maxSpeed));
    }

    public bool IsPaused()
    {
        return paused;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Light" && bigEnough == false)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0);

            if (transform.localScale.x > 2.0f)
            {
                bigEnough = true;
                paused = true;
            }
        }
    }
}
