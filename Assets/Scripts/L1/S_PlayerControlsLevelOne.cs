using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_PlayerControlsLevelOne : MonoBehaviour
{
    private bool paused;

    private Rigidbody2D rb;
    private Animator anim;
    public float movementSpeed = 0.1f;
    public float maxSpeed = 1.5f;

    private bool bigEnough = false;
    public float sizeToGetTo = 1.0f;
    public float scaleSpeed = -0.1f;
    public float riseSpeed = 0.1f;

    public GameObject fadeImage;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointsText;
    private float timer;
    private int points;

    void Start()
    {
        paused = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bigEnough = false;
        fadeImage.SetActive(true);
        timer = 0.0f;
        points = 500;
    }

    public float GetScore()
    {
        return float.Parse(pointsText.text);
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

            timer += Time.deltaTime;
            int seconds = (int)timer;
            string sec = "" + seconds;
            if (seconds < 10)
            {
                sec = "0" + seconds;
            }

            int miliseconds = (int)(timer * 100) - seconds * 100;
            string mil = "" + miliseconds;
            if (miliseconds < 10)
            {
                mil = "0" + miliseconds;
            }

            timeText.text = sec + ":" + mil;

            if (timer > 50.0f)
            {
                pointsText.text = "0";
                points = 0;
            }
            else if (timer > 40.0f)
            {
                pointsText.text = "100";
                points = 100;
            }
            else if (timer > 30.0f)
            {
                pointsText.text = "200";
                points = 200;
            }
            else if (timer > 20.0f)
            {
                pointsText.text = "300";
                points = 300;
            }
            else if (timer > 13.0f)
            {
                pointsText.text = "400";
                points = 400;
            }
        }
    }

    public void Movement()
    {
        float Haxis = Input.GetAxis("Horizontal");
        float Vaxis = Input.GetAxis("Vertical");

        rb.velocity += new Vector2(movementSpeed * Haxis, movementSpeed * Vaxis);

        rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxSpeed), Mathf.Min(rb.velocity.y, maxSpeed));
        rb.velocity = new Vector2(Mathf.Max(rb.velocity.x, -maxSpeed), Mathf.Max(rb.velocity.y, -maxSpeed));

        anim.SetFloat("Horizontal", Haxis);
        anim.SetFloat("Vertical", Vaxis);
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
                anim.SetFloat("Horizontal", 0.0f);
                anim.SetFloat("Vertical", 1.0f);
                PlayerPrefs.SetInt("Level1Points", points);
            }
        }
    }
}
