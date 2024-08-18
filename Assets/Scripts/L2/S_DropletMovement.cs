using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/18/2024
 * Summary: Droplet NPC movement for level 2
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_DropletMovement : MonoBehaviour
{
    [Tooltip("How fast should the gameObject be going")]
    public float movementSpeed;
    private Vector2 newPos; //the position the droplet is heading to
    private float timer; //keeps track of when droplet should move in a different direction
    public GameObject fadeImage;

    /*
     * Initialize private variables
     */
    void Start()
    {
        newPos = transform.position;
        timer = 1.0f + Time.time;
        fadeImage.SetActive(true);
    }

    /*
     * The droplet movement controls 
     */
    void Movement()
    {
        if(Time.time > timer)
        {
            int direction = Random.Range(0, 4);

            switch (direction)
            {
                case 0:
                    newPos.x += 1;
                    break;
                case 1:
                    newPos.x -= 1;
                    break;
                case 2:
                    newPos.y += 1;
                    break;
                case 3:
                    newPos.y -= 1;
                    break;
            }
            timer = 1.0f + Time.time;
        }
       
        //clamps the droplets to the camera boarder
        Vector3 p = Camera.main.WorldToViewportPoint(newPos);
        p.x = Mathf.Clamp(p.x, 0, 1);
        p.y = Mathf.Clamp(p.y, 0, 1);

        //have the droplets move to the new position
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ViewportToWorldPoint(p), movementSpeed * Time.deltaTime);
    }

    /*
     * Continually calls Controls so the player can move
     */
    void Update()
    {
       
        //call Controls so player can move
        Movement();
    }
}
