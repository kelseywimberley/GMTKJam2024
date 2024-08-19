using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControlsLevelThree : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float movementSpeed = 1.25f;
    public float speedLoss = 0.1f;
    public float lowestMovementSpeed = 0.3f;

    private bool grow;
    private float growTimer;
    public float growTimerMax = 0.5f;
    public float growAmount = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();

        if (grow)
        {
            Grow();
        }
    }

    private void Movement()
    {
        float Haxis = Input.GetAxis("Horizontal");

        if (Haxis > 0)
        {
            if (rb.velocity.x < movementSpeed)
            {
                rb.velocity += new Vector2(movementSpeed - rb.velocity.x, 0);
            }
        }
        else if (Haxis < 0)
        {
            if (rb.velocity.x > -movementSpeed)
            {
                rb.velocity += new Vector2(-movementSpeed - rb.velocity.x, 0);
            }
        }

        anim.SetFloat("Horizontal", Haxis);
    }

    private void Grow()
    {
        growTimer += Time.deltaTime;

        if (growTimer > growTimerMax)
        {
            grow = false;
            growTimer = 0.0f;
        }
        else
        {
            transform.localScale += new Vector3(growAmount * Time.deltaTime, growAmount * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Droplet")
        {
            Destroy(collision.gameObject);
            grow = true;
            movementSpeed -= speedLoss;
            movementSpeed = Mathf.Max(movementSpeed, lowestMovementSpeed);
        }
    }
}
