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
       currentDirection = LEFT;
        originalColor = new Color32(32, 59, 132, 255);
      //  leftArrow.material.color = Color.green;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentDirection)
            {
                 
                case UP:
                if (rightArrow.isVisible == true)
                {
                    currentDirection = RIGHT;
                    upArrow.material.color = originalColor;
                    rightArrow.material.color = Color.green;


                }
                else if ((rightArrow.isVisible == false)&(downArrow.isVisible == true))
                {
                    currentDirection = DOWN;
                        upArrow.material.color = originalColor;
                        rightArrow.material.color = originalColor;
                    downArrow.material.color = Color.green;

                    
                }
                    else if ((downArrow.isVisible == false) & (rightArrow.isVisible == false))
                    {

                        currentDirection = LEFT;
                        upArrow.material.color = originalColor;
                        downArrow.material.color = originalColor;
                        rightArrow.material.color = originalColor;
                        leftArrow.material.color = Color.green;
                        Debug.Log("works");
                    }


                    break;
                case RIGHT:
                    if (downArrow.isVisible == true)
                    {
                        currentDirection = DOWN;
                        rightArrow.material.color = originalColor;
                        downArrow.material.color = Color.green;


                    }
                else if ((downArrow.isVisible == false)& (leftArrow.isVisible == true))
                    {
                        currentDirection = LEFT;
                        rightArrow.material.color = originalColor;
                        downArrow.material.color = originalColor;
                        leftArrow.material.color = Color.green;


                    }
                    else if ((downArrow.isVisible == false)&(leftArrow.isVisible == false))
                    {

                        currentDirection = UP;
                        rightArrow.material.color = originalColor;
                        downArrow.material.color = originalColor;
                        leftArrow.material.color = originalColor;
                        upArrow.material.color = Color.green;

                    }

                    break;
                case DOWN:
                    if (leftArrow.isVisible == true)
                    {
                        currentDirection = LEFT;
                        downArrow.material.color = originalColor;
                        leftArrow.material.color = Color.green;


                    }
                    else if ((leftArrow.isVisible == false) &(upArrow.isVisible == true))
                    {
                        currentDirection = UP;
                        downArrow.material.color = originalColor;
                        leftArrow.material.color = originalColor;
                        upArrow.material.color = Color.green;


                    }
                    else if ((leftArrow.isVisible == false) & (upArrow.isVisible == false))
                    {

                        currentDirection = RIGHT;
                        upArrow.material.color = originalColor;
                        downArrow.material.color = originalColor;
                        leftArrow.material.color = originalColor;
                        rightArrow.material.color = Color.green;

                    }

                    break;
                case LEFT:
                    if (upArrow.isVisible == true)
                    {
                        currentDirection = UP;
                        leftArrow.material.color = originalColor;
                        upArrow.material.color = Color.green;


                    }
                    else if ((upArrow.isVisible == false) &(rightArrow.isVisible == true))
                    {
                        currentDirection = RIGHT;
                        upArrow.material.color = originalColor;
                        leftArrow.material.color = originalColor;
                        rightArrow.material.color = Color.green;


                    }
                    else if ((upArrow.isVisible == false) & (rightArrow.isVisible == false))
                    {

                        currentDirection = DOWN;
                        upArrow.material.color = originalColor;
                        leftArrow.material.color = originalColor;
                        rightArrow.material.color = originalColor;
                       downArrow.material.color = Color.green;

                    }

                    break;
                default:
                    break;
            }
        }
    }


   /* void OnTriggerEnter(Collider collider)
    {
   
      if (collider.transform.tag == "HandPointer")
        {
            switch (currentDirection)
            {
                case UP:
                    if (rightArrow.isVisible==true) { 
                    currentDirection = RIGHT;
                    upArrow.material.color = originalColor;
                    rightArrow.material.color = Color.green;

                       
                    }
                    else if (rightArrow.isVisible == false)
                    { currentDirection = LEFT;
                        rightArrow.material.color = originalColor;
                        downArrow.material.color = Color.green;

                        Debug.Log("rightGone");
                    }

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
    }*/

}
