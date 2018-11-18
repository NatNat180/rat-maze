using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{

    public Transform[] movableWalls;
    private float smoothMotion = 5.0f;
    private Quaternion[] originalRotations;
    public Vector3 neededRotation;
    private bool isSwitchPressed;
    private bool coolDownActive;
    private float coolDownTimer = 1.5f;

    void Start()
    {
        originalRotations = new Quaternion[movableWalls.Length];
        for (int i = 0; i < movableWalls.Length; i++)
        {
            originalRotations[i] = movableWalls[i].rotation;
        }

        isSwitchPressed = false;
        coolDownActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Rat")
        {
            coolDownActive = true;
            isSwitchPressed = !isSwitchPressed;
        }
    }

    void Update()
    {
        if (isSwitchPressed)
        {
            for (int i = 0; i < movableWalls.Length; i++)
            {
                movableWalls[i].rotation = Quaternion.Slerp(movableWalls[i].rotation, Quaternion.Euler(neededRotation), Time.deltaTime * smoothMotion);
            }
        }
        else
        {
            for (int i = 0; i < movableWalls.Length; i++)
            {
                movableWalls[i].rotation = Quaternion.Slerp(movableWalls[i].rotation, originalRotations[i], Time.deltaTime * smoothMotion);
            }
        }

        if (coolDownActive == true)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0f)
        {
            coolDownActive = false;
            coolDownTimer = 1.5f;
        }
    }
}
