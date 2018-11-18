﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    private Rigidbody ratBody;
    public float speed = 0.3f;
    private bool moveToggle = false;
    public static bool RatInMaze = true; // set to false when the game is ready
    private Animator animator;

    void Start()
    {
        ratBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get movement toggle from spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveToggle = !moveToggle;
        }

        // mouse movement based on movement toggle
        if (moveToggle)
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
            transform.position = collider.transform.position;
            //ratTurn();
            DirectionalTile tile = collider.gameObject.GetComponentInChildren<DirectionalTile>();
            switch (tile.CurrentDirection)
            {
                case "UP":
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case "RIGHT":
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case "DOWN":
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case "LEFT":
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                    break;
                default:
                    break;
            }
        }
    }

    /*private void ratTurn()
    {
        ratBody.velocity = Vector3.zero;
        animator.SetTrigger("Turning");
    }*/
}
