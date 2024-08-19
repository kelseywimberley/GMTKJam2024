using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class S_FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("ScoreTracker").GetComponent<S_ScoreTracker>().FinalScore().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
