using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* Author: Erin Scribner
 * Date: 8/17/2024
 * Summary: when button is pressed, go back to the level player was previously on
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_BackToGame : MonoBehaviour
{
    /*
     * Activates the BackToGame function every time the button is pressed
     */
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(BackToGame);
    }

    /*
     * Loads back to the level the player was previously on
     */
    void BackToGame()
    {
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Data").GetComponent<S_StoreLevelData>().levelName);
    }

    void Update() { }
}
