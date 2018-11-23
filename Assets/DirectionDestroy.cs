using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDestroy : MonoBehaviour
{
    private Renderer Rndr;
    void Start()
    {
        Rndr = GetComponent<Renderer>();
    }



    void OnTriggerEnter(Collider collider)
    {

        if (collider.transform.tag == "Wall")
        {
            Rndr.enabled = false;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "Wall")
        {
            Rndr.enabled = true;
        }
    }
}