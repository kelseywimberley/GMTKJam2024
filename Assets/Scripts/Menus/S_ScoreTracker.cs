using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private float Level1Score;
    private float Level2Score;
    private float Level3Score;
    void Start()
    {
        Level1Score = 0;
        Level2Score = 0;
        Level3Score = 0;
    }

    public string FinalScore()
    {
       float finalScore = Level1Score + Level2Score + Level3Score;
       return finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            Level1Score = GameObject.FindGameObjectWithTag("Player").GetComponent<S_PlayerControlsLevelOne>().GetScore();
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            Level2Score = GameObject.FindGameObjectWithTag("Player").GetComponent<S_DropletCounter>().GetDropletNum();
        }
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            Level3Score = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
        }
    }
}
