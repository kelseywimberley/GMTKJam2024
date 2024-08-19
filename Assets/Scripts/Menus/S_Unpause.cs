using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* Author: Erin Scribner
 * Date: 8/17/2024
 * Summary: Unpauses the game when the button is pressed
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_Unpause : MonoBehaviour
{
    /*
     * Activates the UnPause function when button is clicked
     */
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(UnPause);
    }

    /*
     * unpauses the game and hides the puase screen
     */
    void UnPause()
    {
        GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    void Update() { }
}
