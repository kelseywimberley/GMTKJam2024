using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: NPC movemet for level 3
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_NPCMovement : MonoBehaviour
{
    [Tooltip("How fast should the player be going")]
    public float speed;
    private Vector2 newPosition; //the new position the NPC needs to move to
    private float timer; //determins when the player should move in a different direction
    private int direction; //determins which direction the NPC should move in
    private Animator anim;

    /*
     * Initialie private variables
     */
    void Start()
    {
        newPosition = transform.position;
        timer = 1.0f + Time.time;
        direction = 0;
        anim = GetComponent<Animator>();
    }

    /*
     * if the NPC hits a wall, have it go the opposite direction
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if NPC hits a wall
        if(collision.gameObject.tag == "Wall")
        {
            //and it was going left
            if(direction == 0)
            {
                //have NPC go right
                newPosition.x += 1;
                anim.SetFloat("Horizontal", 0.0f);
            }
            //if it was going right
            else if(direction == 1)
            {
                //have NPC go left
                newPosition.x -= 1;
                anim.SetFloat("Horizontal", 0.0f);
            }
        }
    }

    /*
     * Has the NPC move in a random direction
     */
    void Movement()
    {
        //if enough time has past
        if(Time.time > timer)
        {
            //randomly pick a direction for the NPC to move i
            direction = Random.Range(0, 2);

            //If direction is 0, then have the NPC go left
            if (direction == 0)
            {
                newPosition.x -= 1;
                anim.SetFloat("Horizontal", -1.0f);
            }
            //If direction is 1, then have the NPC go right
            else if (direction == 1)
            {
                newPosition.x += 1;
                anim.SetFloat("Horizontal", 1.0f);
            }
            //update timer to the next time check
            timer = 1.0f + Time.time;
        }

        //clamps the gameObject to the camera boarder
        Vector3 p = Camera.main.WorldToViewportPoint(newPosition);
        p.x = Mathf.Clamp(p.x, 0, 1);
        p.y = Mathf.Clamp(p.y, 0, 1);

        //have NPC move to the new position
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ViewportToWorldPoint(p), speed * Time.deltaTime);
    }

    /*
     * Call Movement
     */
    void Update()
    {
        Movement();
    }
}
