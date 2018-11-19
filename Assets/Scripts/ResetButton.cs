﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

    public static bool ResetPressed;

    void Start()
    {
        ResetPressed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "HandPointer")
        {
            ResetPressed = true;
        }
    }
}