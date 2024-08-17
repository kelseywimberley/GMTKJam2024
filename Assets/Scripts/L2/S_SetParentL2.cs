using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Sets the newly spawned gameObject's parent to be the player
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_SetParentL2 : MonoBehaviour
{
    /*
     * Have the gameObject's parent be the player
     */
    void Awake()
    {
        //find the player in the scene
        GameObject newParent = GameObject.FindGameObjectWithTag("Player");
        //if the player was found
        if(newParent)
        {
            //set the gameobject's parent = to the player
            gameObject.transform.parent = newParent.transform;
        }
    }

    void Update() { }
}
