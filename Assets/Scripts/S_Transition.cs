using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Transition : MonoBehaviour
{
    private Image image;
    private bool loadIn;
    private bool loadOut;
    public float speed = 0.3f;

    void Start()
    {
        image = GetComponent<Image>();
        loadIn = true;
    }

    void Update()
    {
        if (loadOut)
        {
            float newAlpha = image.color.a + (speed * 2.0f * Time.deltaTime);
            if (newAlpha > 1)
            {
                newAlpha = 1;
                image.color = new Vector4(0, 0, 0, newAlpha);
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");
                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (SceneManager.GetActiveScene().name == "Level3")
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
            image.color = new Vector4(0, 0, 0, newAlpha);
        }

        if (loadIn)
        {
            float newAlpha = image.color.a - (speed * Time.deltaTime);
            if (newAlpha < 0)
            {
                newAlpha = 0;
                image.color = new Vector4(0, 0, 0, newAlpha);
                loadIn = false;
                loadOut = true;
                gameObject.SetActive(false);
            }
            image.color = new Vector4(0, 0, 0, newAlpha);
        }
    }
}
