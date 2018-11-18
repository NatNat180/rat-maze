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
            isRatMoving = false;
            animator.SetTrigger("Turning");
            StartCoroutine(RatTurnAnimate(collider));
        }
    }

    IEnumerator RatTurnAnimate(Collider collider)
    {
        transform.position = collider.transform.position;
        yield return new WaitForSeconds(2f);
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
        isRatMoving = true;
    }
}
