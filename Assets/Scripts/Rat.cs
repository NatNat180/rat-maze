﻿﻿using System.Collections;
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
                && ratBody.rotation.eulerAngles != Quaternion.Inverse(currentTileDirection).eulerAngles)
            {
                isRatMoving = false;
                animator.SetTrigger("Turning");
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
        transform.position = collider.transform.position;
        yield return new WaitForSeconds(2f);
        transform.rotation = tileDirection;
        isRatMoving = true;
    }
}
