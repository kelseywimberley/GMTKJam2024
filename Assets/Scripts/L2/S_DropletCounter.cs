using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Erin Scribner
 * Date: 8/16/2024
 * Summary: Has several public functions that controls how many water droplets a game object has
 * Public Functions: GetDropletNum, IncrementDropletNum, DecrementDropletNum
 * Other Scripts Needed: None
 */
public class S_DropletCounter : MonoBehaviour
{
    private int dropletNum; //how many water droplets the gameObject has

   /*
    * Initialize private variables
    */
    void Start()
    {
        dropletNum = 0;
    }

    /*
     * return the current number of water droplets
     */
    public int GetDropletNum()
    {
        return dropletNum;
    }

    /*
     * Increments the number of water droplets by 1
     */
    public void IncrementDropletNum()
    {
        dropletNum++;
    }

    /*
     * Decrements the number of water droplets by 1
     */
    public void DecrementDropletNum()
    {
        dropletNum--;
    }

    void Update() { }
}
