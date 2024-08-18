using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Author: Erin Scribner
 * Date: 8/17/2024
 * Summary: Doesn't destroy the gameobject when a new scene is loaded
 * Public Functions: None
 * Other Scripts Needed: None
 */
public class S_StoreLevelData : MonoBehaviour
{
    [Tooltip("Stores the current level name")]
    public string levelName;
    /*
     * Doesn't destroy the gameObject when a new scene is loaded in
     */
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update() { }
}
