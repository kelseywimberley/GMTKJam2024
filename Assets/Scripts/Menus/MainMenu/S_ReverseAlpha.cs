using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ReverseAlpha : MonoBehaviour
{
    public ParticleSystem rain;
    public ParticleSystem evap;
    public float growTime;
    private Color baseColor;
    private float time;
    private bool flag;
    private bool playEvap;
    // Start is called before the first frame update
    void Awake()
    {
        baseColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.clear;
        time = growTime + Time.time;
        baseColor.a = 0;
        flag = false;
        playEvap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(rain.isPlaying == true && flag == false)
        {
            if(Time.time > time)
            {
                baseColor.a += 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                time = growTime + Time.time;

                if (baseColor.a >= 1)
                {
                    baseColor.a = 1;
                    flag = true;
                    playEvap = true;
                }
            }
        }

        else if(rain.isPlaying == false && flag == true)
        {
            if (Time.time > time)
            {
                baseColor.a -= 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                time = growTime + Time.time;

                if (baseColor.a <= 0.003f)
                {
                    baseColor.a = 0;
                    flag = false;
                }
                if(playEvap == true)
                {
                    evap.Play();
                    playEvap = false;
                }
            }
        }
    }
}
