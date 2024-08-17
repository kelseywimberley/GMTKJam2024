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
    public float sizeToGetTo = 1.0f;
    public float scaleSpeed = -0.1f;
    public float riseSpeed = 0.1f;

    public GameObject fadeImage;

    void Start()
    {
        paused = false;
        rb = GetComponent<Rigidbody2D>();
        bigEnough = false;
        fadeImage.SetActive(true);
    }

    void Update()
    {
        if (bigEnough)
        {
            rb.velocity += new Vector2(0, riseSpeed * Time.deltaTime);

            if (transform.position.y > 6.0f)
            {
                fadeImage.SetActive(true);
            }
        }
        else if (paused)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            Movement();
        }
    }

    public void Movement()
    {
        float Haxis = Input.GetAxis("Horizontal");
        float Vaxis = Input.GetAxis("Vertical");

        rb.velocity += new Vector2(movementSpeed * Haxis, movementSpeed * Vaxis);

        rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxSpeed), Mathf.Min(rb.velocity.y, maxSpeed));
        rb.velocity = new Vector2(Mathf.Max(rb.velocity.x, -maxSpeed), Mathf.Max(rb.velocity.y, -maxSpeed));
    }

    public bool IsPaused()
    {
        return paused;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Light" && !bigEnough && !paused)
        {
            transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, 0);

            if (transform.localScale.x < sizeToGetTo)
            {
                GetComponent<CircleCollider2D>().isTrigger = true;
                bigEnough = true;
                paused = true;
            }
        }
    }
}
