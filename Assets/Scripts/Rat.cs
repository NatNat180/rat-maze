﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public AudioClip Click;
    private Rigidbody ratBody;
    public float speed = 0.3f;
    public static bool RatInMaze = false;
    private bool isRatMoving = true;
    private Animator animator;
    private float rotationSpeed = 5.0f;
    private float coolDown = 0.0f;
    public Transform spawnPoint;
    public static bool RatReset = false;

    void Start()
    {
        ratBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (coolDown > 0.0f)
        {
            coolDown -= Time.deltaTime;
        }

        if (ResetButton.ResetPressed)
        {
            ResetButton.ResetPressed = false;
            RatInMaze = true;
            isRatMoving = true;
            RatReset = true;
            Vector3 newSpawn = spawnPoint.transform.position;
            transform.position = new Vector3(newSpawn.x, 7.379f, newSpawn.z);
            Debug.Log("position = " + transform.position);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    void FixedUpdate()
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
        if (collider.transform.tag == "DirectionalTile" && coolDown <= 0.0f)
        {
            // start cooldown (counts down in Update) so that tile cannot be pressed twice immediately
            coolDown = 0.5f;
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

            if (ratBody.rotation.eulerAngles != currentTileDirection.eulerAngles
                && ratBody.rotation.eulerAngles != Quaternion.Inverse(currentTileDirection).eulerAngles
                && (ratBody.rotation.eulerAngles.y + 180).ToString() != currentTileDirection.eulerAngles.y.ToString()
                && (ratBody.rotation.eulerAngles.y - 180).ToString() != currentTileDirection.eulerAngles.y.ToString())
            {
                //isRatMoving = false;
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

        // float elapsedTime = 0.0f;
        // float time = 1.0f;
        // animator.SetTrigger("Turning");
        // // lerp location change of mouse
        // while (elapsedTime < time)
        // {
        //     elapsedTime += Time.deltaTime;
        //     transform.position = Vector3.Lerp(transform.position, collider.transform.position, (elapsedTime / time) * 2.0f);
        //     yield return new WaitForEndOfFrame();
        // }

        // // reset elapsed time in preparation for use in rotation
        // elapsedTime = 0.0f;

        // // rotate mouse
        // Quaternion startingRotation = transform.rotation;
        // while (elapsedTime < time)
        // {
        //     elapsedTime += Time.deltaTime;
        //     transform.rotation = Quaternion.Slerp(startingRotation, tileDirection, (elapsedTime / time) * rotationSpeed);
        //     yield return new WaitForEndOfFrame();
        // }
        // isRatMoving = true;
        AudioSource audio = GetComponent<AudioSource>(); 
        audio.clip = Click;
        audio.Play();
        animator.SetTrigger("Turning");
        float elapsedTime = 0.0f;
        float time = 0.75f;

        Vector3 startingPosition = transform.localPosition;
        Quaternion startingRotation = transform.rotation; // have a startingRotation as well
        Quaternion targetRotation = Quaternion.Euler(tileDirection.eulerAngles);

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here
            transform.localPosition = Vector3.Lerp(startingPosition, collider.transform.position, (elapsedTime / time));

            // Rotations
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, (elapsedTime / time));
            yield return new WaitForFixedUpdate();
        }
    }

}
