using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControlsLevelThree : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float movementSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
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
}
