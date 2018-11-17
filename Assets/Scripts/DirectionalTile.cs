using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalTile : MonoBehaviour {

    private const string UP = "UP";
    private const string RIGHT = "RIGHT";
    private const string DOWN = "DOWN";
    private const string LEFT = "LEFT";
    private string currentDirection;

    public string CurrentDirection
    {
        get { return currentDirection; }
    }

    void Start()
    {
        currentDirection = UP;
    }

    void Update()
    {
		Debug.Log(currentDirection);
    }

    void OnMouseDown()
    {
        transform.Rotate(0, 90, 0);
        switch (currentDirection)
        {
            case UP:
                currentDirection = RIGHT;
                break;
            case RIGHT:
                currentDirection = DOWN;
                break;
            case DOWN:
                currentDirection = LEFT;
                break;
            case LEFT:
                currentDirection = UP;
                break;
            default:
                break;
        }
    }
}
