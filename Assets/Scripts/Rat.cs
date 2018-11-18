﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    private Rigidbody ratBody;
    public float speed = 0.3f;
    public static bool RatInMaze = true; // set to false when the game is ready
    private bool isRatMoving = true;
    private Animator animator;
    private float rotationSpeed = 5.0f;

    void Start()
    {
        ratBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isRatMoving)
        {
            ratBody.velocity = transform.forward * speed;
        }
        else
        {
            ratBody.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "DirectionalTile")
        {
            Quaternion currentTileDirection = Quaternion.Euler(0, 0, 0);
            DirectionalTile tile = collider.gameObject.GetComponentInChildren<DirectionalTile>();
            switch (tile.CurrentDirection)
            {
                case "UP":
                    currentTileDirection = Quaternion.Euler(0, 0, 0);
                    break;
                case "RIGHT":
                    currentTileDirection = Quaternion.Euler(0, 90, 0);
                    break;
                case "DOWN":
                    currentTileDirection = Quaternion.Euler(0, 180, 0);
                    break;
                case "LEFT":
                    currentTileDirection = Quaternion.Euler(0, 270, 0);
                    break;
                default:
                    break;
            }

            float sum = ratBody.rotation.eulerAngles.y + 180;
            if (ratBody.rotation.eulerAngles != currentTileDirection.eulerAngles
                && ratBody.rotation.eulerAngles != Quaternion.Inverse(currentTileDirection).eulerAngles
                && (ratBody.rotation.eulerAngles.y + 180).ToString() != currentTileDirection.eulerAngles.y.ToString()
                && (ratBody.rotation.eulerAngles.y - 180).ToString() != currentTileDirection.eulerAngles.y.ToString())
            {
                isRatMoving = false;
                StartCoroutine(RatTurnAnimate(collider, currentTileDirection));
            }
            else
            {
                transform.rotation = currentTileDirection;
            }
        }
    }

    IEnumerator RatTurnAnimate(Collider collider, Quaternion tileDirection)
    {
        float elapsedTime = 0.0f;
        float time = 1.0f;
        animator.SetTrigger("Turning");

        // lerp location change of mouse
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, collider.transform.position, (elapsedTime / time));
            yield return new WaitForEndOfFrame();
        }

        // reset elapsed time in preparation for use in rotation
        elapsedTime = 0.0f;

        // rotate mouse
        Quaternion startingRotation = transform.rotation;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startingRotation, tileDirection, (elapsedTime / time) * rotationSpeed);
            yield return new WaitForEndOfFrame();
        }
        isRatMoving = true;
    }

}
