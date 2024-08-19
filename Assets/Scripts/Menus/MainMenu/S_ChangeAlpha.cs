using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChangeAlpha : MonoBehaviour
{
    public float evaporationTime;
    public ParticleSystem rain;
    public ParticleSystem evap;
    private float time;
    private Color baseColor;
    private bool flag;
    private bool playRain;
    // Start is called before the first frame update
    void Start()
    {
        time = evaporationTime + Time.time;
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        flag = false;
        playRain = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time)
        {
            if(flag == false && evap.isPlaying == false)
            {
                if(rain && playRain == true)
                {
                    rain.Play();
                    playRain = false;
                }
                baseColor.a -= .1f;
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                time = evaporationTime + Time.time;

                if (baseColor.a <= 0.001f)
                {
                    baseColor.a = 0;
                    flag = true;
                }
            }
            else if(flag == true && evap.isPlaying == true)
            {
                if(rain)
                {
                    rain.Stop();
                }
                baseColor.a += .1f;
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                time = evaporationTime + Time.time;

                if (baseColor.a >= 1)
                {
                    baseColor.a = 1;
                    flag = false;
                    playRain = true;
                }
            }
        }
    }
}
