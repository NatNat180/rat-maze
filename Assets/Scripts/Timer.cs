using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    public AudioClip Click;
    public float timeLeft;
	public TextMeshPro timerText;

    void Start()
    {
        timeLeft = 300.0f;
    }

    void Update()
    {
        if (Rat.RatInMaze == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = Click;
            audio.Play();
            timeLeft -= Time.deltaTime;
            string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
            string seconds = (timeLeft % 60).ToString("00");
			timerText.text = string.Format("{0}:{1}", minutes, seconds);
            if (timeLeft <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (Rat.RatReset)
        {
            //Rat.RatInMaze = true;
            timeLeft = 300.0f;
            Rat.RatReset = false;
        }
    }
}
