using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeLeft;

    void Start()
    {
        timeLeft = 300.0f;
    }

    void Update()
    {
        if (Rat.RatInMaze == true)
        {
            timeLeft -= Time.deltaTime;
            string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
            string seconds = (timeLeft % 60).ToString("00");
            Debug.Log("Time left = " + string.Format("{0}:{1}", minutes, seconds));
            if (timeLeft <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
