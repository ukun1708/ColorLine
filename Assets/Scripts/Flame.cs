using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
   
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }

        if (PathMover.Singleton.gameObject.GetComponent<MeshRenderer>().enabled == false)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
}
