using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {
    public AudioClip Click;
    public ParticleSystem particleSystem;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Rat")
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.clip = Click;
            audio.Play();
            particleSystem.Play();
        }
    }

}
