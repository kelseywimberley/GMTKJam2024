using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
