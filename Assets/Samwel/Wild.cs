using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wild : MonoBehaviour
{
  public float movementSpeed = 1f; // Speed of movement
    public float distance = 1f; // Unit distance to move

    private int movementIndex = 0; // Index to keep track of the current movement in the pattern
    private float movementTimer = 0f; // Timer to track the movement progress
    private bool isMoving = false; // Flag to indicate if the object is currently moving

    private Vector3[] movements = new Vector3[] {
        Vector3.up,
        Vector3.down,
        Vector3.right,
        Vector3.left,
        Vector3.left,
        Vector3.right,
        Vector3.down,
        Vector3.up
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (isMoving)
        {
            // Move the object in the specified pattern
            float step = movementSpeed * Time.deltaTime;
            transform.Translate(movements[movementIndex] * step);

            // Update the movement timer
            movementTimer += step;

            // Check if the movement distance has been reached
            if (movementTimer >= distance)
            {
                // Reset the movement timer and stop moving
                movementTimer = 0f;
                isMoving = false;
            }
        }
        else
        {
            // Start the next movement
            movementIndex = (movementIndex + 1) % movements.Length;
            isMoving = true;
        }
    }
}
