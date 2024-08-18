using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Activates an object on or off
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_Activate : MonoBehaviour
{
    [Tooltip("The menu gameObject whose active stat we want to toggle")]
    public GameObject Menu;
    private bool toggle; //activates/deactivates the object
    
    /*
     * initialize private variables
     */
    void Start()
    {
        toggle = false;
    }

   /*
    * toggles the public variable on/off when the Cancel button is pressed
    */
    void Update()
    {
        //if the cancel button is pressed
        if(Input.GetButtonDown("Cancel"))
        {
            //set the menu's activate status to the opposite of toggle
            Menu.SetActive(!toggle);
            //have toggle = its opposite
            toggle = !toggle;

            //pauses game by setting timescale to 0
            if(toggle == true)
            {
                Time.timeScale = 0;
            }
            //unpauses game by setting timescale to 1
            else if(toggle == false)
            {
                Time.timeScale = 1;
            }
        }
    }
}
