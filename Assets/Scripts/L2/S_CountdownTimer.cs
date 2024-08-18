using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/* Author: Erin Scribner
 * Date: 8/17/2024
 * Summary: A countdown timer
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_CountdownTimer : MonoBehaviour
{
    [Tooltip("How many seconds the player has to complete the level")]
    public float maxTime;
    private float time; //keepts track of when to update the timer
    
    /*
     * Initialize private variables
     */
    void Start()
    {
        time = 1.0f + Time.time;
        gameObject.GetComponent<TextMeshProUGUI>().SetText(maxTime.ToString());
    }

    /*
     * Countsdown the timer every second
     */
    void Update()
    {
        //when a second has past
        if(Time.time > time)
        {
            //decrement the timer
            maxTime--;
            //if the timer is less then or equal to 0
            if (maxTime <= 0)
            {
                //set it equal to zero
                maxTime = 0;
                //when timer is 0, go to level 3
                SceneManager.LoadScene("Level3");
            }

            //when timer is almost over
            if(maxTime <= 10)
            {
                //have its color change
                gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            //update the countdown text
            gameObject.GetComponent<TextMeshProUGUI>().SetText(maxTime.ToString());
            //set time to the next second
            time = 1.0f + Time.time;
        }
    }
}
