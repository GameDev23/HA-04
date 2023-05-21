using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zigzag : MonoBehaviour
{
    public float speed = 0.5f; // Speed at which the object moves horizontally
    public float amplitude = 1.5f; // Amplitude of the zigzag movement
    public float frequency = 2f; // Frequency of the zigzag movement

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the horizontal movement
        float horizontalMovement = Mathf.Cos(Time.time * frequency) * amplitude;

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalMovement, -speed, 0) * Time.deltaTime;

        // Apply the movement to the object's position
        transform.Translate(movement);
    }
}
