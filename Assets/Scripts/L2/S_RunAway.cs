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
    private GameObject[] player; //stores the player's data

    void Start() { }

   /*
    * Has the gameObject move away from the player if the player tagged game object is too close
    */
    void Update()
    {
        //find all of the gameobjects that have the player tag
        player = GameObject.FindGameObjectsWithTag("Player");
        //go through them the check their distance
        for (int i = 0; i < player.Length; i++)
        {
            //if player is in the scene
            if (player[i])
            {
                //check to see if the player is close enough to the gameObject
                if (Vector2.Distance(player[i].transform.position, transform.position) <= distance)
                {
                    //if so, then have the gameObject run away. This occures by having speed be negative
                    transform.position = Vector2.MoveTowards(transform.position, player[i].transform.position, -speed * Time.deltaTime);

                    //clamps the gameObject to the camera boarder
                    Vector3 p = Camera.main.WorldToViewportPoint(transform.position);
                    p.x = Mathf.Clamp(p.x, 0, 1);
                    p.y = Mathf.Clamp(p.y, 0, 1);
                    transform.position = Camera.main.ViewportToWorldPoint(p);
                }
            }
        }
    }
}
