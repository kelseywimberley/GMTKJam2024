using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class S_BackToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(BackToGame);
    }

    void BackToGame()
    {
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Data").GetComponent<S_StoreLevelData>().levelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
