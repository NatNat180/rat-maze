using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

    public ParticleSystem particleSystem;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Rat")
        {
            particleSystem.Play();
        }
    }

}
