using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Has droplets stick to player if gameObject runs into it
 * Public Functions: None
 * Other Scripts Needed: IncrementDropletNum
 */
public class S_DropletStickL2 : MonoBehaviour
{
    [Tooltip("The gameObject that acts as the water droplet to spawn")]
    public GameObject stuckWaterDroplet;
   
    void Start() { }

    /*
     * If the gameObject collides with a water droplet, have it stick to the 
     * gameObject
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if gameObject collides with a water droplet
        if(collision.gameObject.tag == "Droplet")
        {
            //and if the gameObject has a droplet counter
            if(gameObject.GetComponent<S_DropletCounter>())
            {
                //increment the droplet counter
                gameObject.GetComponent<S_DropletCounter>().IncrementDropletNum();
            }
            //otherwise the gameobject is a child of the player
            else
            {
                //so increment its parent's droplet counter
                gameObject.transform.parent.gameObject.GetComponent<S_DropletCounter>().IncrementDropletNum();
            }
            //spawn a water droplet
            Instantiate(stuckWaterDroplet, collision.gameObject.transform.position, Quaternion.identity);
            //destroy the temp water droplet
            Destroy(collision.gameObject);
        }
    }

    void Update() { }
}
