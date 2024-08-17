using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* Author: Erin Scribner
 * Date: 8/17/2024
 * Summary: Loads in a scene when the button is clicked
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_NextScene : MonoBehaviour
{
    [Tooltip("The name of the scene you want to go to")]
    public string sceneName;
   
    /*
     * Add the NextScene function to the button's listener
     */
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(NextScene);
    }

    /*
     * Load in the next scene
     */
    void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update() { }
}
