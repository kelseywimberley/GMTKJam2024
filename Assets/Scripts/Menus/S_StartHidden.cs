using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Has the object start off as not active
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_StartHidden : MonoBehaviour
{
    /*
     * Starts the object off as not active
     */
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update() { }
}
