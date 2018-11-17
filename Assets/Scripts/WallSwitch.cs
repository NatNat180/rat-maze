using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{

    public Transform movableWall;
    private float smoothMotion = 5.0f;
    private Quaternion originalRotation;
    private Quaternion ninetyDegrees = Quaternion.Euler(0, 90, 0);
    private Quaternion zeroDegrees = Quaternion.Euler(0, 0, 0);
    private bool isSwitchPressed;
    private bool coolDownActive;
    private float coolDownTimer = 1.5f;

    void Start()
    {
        originalRotation = movableWall.rotation;
        isSwitchPressed = false;
        coolDownActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Rat".Equals(other.tag))
        {
            coolDownActive = true;
            isSwitchPressed = !isSwitchPressed;
        }
    }

    void Update()
    {
        // This if-condition will need to be taken out - using now for testing purposes
        if (Input.GetKeyDown(KeyCode.Space) && coolDownActive == false)
        {
            coolDownActive = true;
            isSwitchPressed = !isSwitchPressed;
        }
        // This if-condition will need to be taken out - using now for testing purposes

        if (isSwitchPressed)
        {
            movableWall.rotation = Quaternion.Slerp(movableWall.rotation, ninetyDegrees, Time.deltaTime * smoothMotion);
        }
        else
        {
            movableWall.rotation = Quaternion.Slerp(movableWall.rotation, originalRotation, Time.deltaTime * smoothMotion);
        }

        if (coolDownActive == true)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0f)
        {
            coolDownActive = false;
            coolDownTimer = 3.0f;
        }
    }
}
