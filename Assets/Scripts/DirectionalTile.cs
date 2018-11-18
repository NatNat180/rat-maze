using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalTile : MonoBehaviour
{

    private const string UP = "UP";
    private const string RIGHT = "RIGHT";
    private const string DOWN = "DOWN";
    private const string LEFT = "LEFT";
    private string currentDirection;
    public Renderer upArrow;
    public Renderer leftArrow;
    public Renderer rightArrow;
    public Renderer downArrow;
    private Color originalColor;

    public string CurrentDirection
    {
        get { return currentDirection; }
    }

    void Start()
    {
        currentDirection = DOWN;
        originalColor = new Color32(32, 59, 132, 255);
        downArrow.material.color = Color.green;
    }

    void Update()
    {
        Debug.Log(currentDirection);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "HandPointer")
        {
            switch (currentDirection)
            {
                case UP:
                    currentDirection = RIGHT;
                    upArrow.material.color = originalColor;
                    rightArrow.material.color = Color.green;
                    break;
                case RIGHT:
                    currentDirection = DOWN;
                    rightArrow.material.color = originalColor;
                    downArrow.material.color = Color.green;
                    break;
                case DOWN:
                    currentDirection = LEFT;
                    downArrow.material.color = originalColor;
                    leftArrow.material.color = Color.green;
                    break;
                case LEFT:
                    currentDirection = UP;
                    leftArrow.material.color = originalColor;
                    upArrow.material.color = Color.green;
                    break;
                default:
                    break;
            }
        }
    }

}
