using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Player controls for Level 2
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_PlayerMovementL2 : MonoBehaviour
{
    [Tooltip("How fast should the player be going")]
    public float movementSpeed;
    private Vector2 newPos; //the position the player is heading to
    private float startingSpeed; //stores the normal speed of the player
    private bool changeSpeed; //determins if the player should change its speed

    /*
     * Initialize private variables
     */
    void Start()
    {
        startingSpeed = movementSpeed;
        changeSpeed = false;
        newPos = transform.position;
    }

    /*
     * If player has enough raindrops, have its speed decrease by half
     */
    void SpeeedManipulator()
    {
        //if the player has atleast 5 raindrops 
        if(gameObject.GetComponent<S_DropletCounter>().GetDropletNum() >= 5)
        {
            //its speed does need to be changed
            changeSpeed = true;
            //so cut the player's speed by half
            movementSpeed /= 2;
        }
    }

    /*
     * The player controls 
     */
    void Controls()
    {
        //Use GetAxis to determine which buttons the player has pressed.
        //This allows for us to change the buttons in the player settings rather then
        //hard coding the keys in code
        float Haxis = Input.GetAxis("Horizontal");
        float Vaxis = Input.GetAxis("Vertical");
        //if the left/right key has been pressed
        if(Haxis != 0)
        {
            //have newPos.x increase by Haxis
            newPos.x += Haxis;
        }
        //otherwise if the left/right key has not been pressed
        else if(Haxis == 0)
        {
            //set newPos.x = to the player's current x value
            newPos.x = transform.position.x;
        }
        //if the up/down key has been pressed
        if(Vaxis != 0)
        {
            //have newPos.y increase by Vaxis
            newPos.y += Vaxis;
        }
        //otherwise if the up.down key has not been pressed
        else if(Vaxis == 0)
        {
            //set newPos.y = to the player's current y value
            newPos.y = transform.position.y;
        }

        //have the player move to the new position
        transform.position = Vector2.MoveTowards(transform.position, newPos, movementSpeed * Time.deltaTime);
    }

    /*
     * Continually calls Controls so the player can move
     */
    void Update()
    {
        //if the player shouldn't change its speed
        if(changeSpeed == false)
        {
            //check to see if it needs to by calling SpeedManipulator
            SpeeedManipulator();
        }
        //call Controls so player can move
        Controls();
    }
}
