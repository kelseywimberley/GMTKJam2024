using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Has droplets run away if player gets too close
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_RunAway : MonoBehaviour
{
    [Tooltip("How close the player needs to get before the gameObject start running")]
    public float distance;
    [Tooltip("How fast the gameObject can move")]
    public float speed;
    private GameObject player; //stores the player's data

    /*
     * Initialize private variables
     */
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

   /*
    * Has the gameObject move away from the player if the player is too close
    */
    void Update()
    {
        //if player is in the scene
        if (player)
        {
            //check to see if the player is close enough to the gameObject
            if (Vector2.Distance(player.transform.position, transform.position) <= distance)
            {
                //if so, then have the gameObject run away. This occures by having speed be negative
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }
    }
}
