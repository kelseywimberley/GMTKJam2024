using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnPart : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Instantiate(particle, new Vector2(transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
