using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float radius = 2f; // Radius of the circular path
    public float rotationSpeed = 90f; // Speed at which the object rotates in degrees per second
    private float xOffset;
    private float yOffset;

    private float angle = 0f; // Current angle in radians

    // Start is called before the first frame update
    void Start()
    {
        xOffset = transform.position.x;
        yOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position along the circular path using polar coordinates
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Update the object's position
        transform.position = new Vector3(x+xOffset, y+yOffset, transform.position.z);

        // Update the angle for the next frame
        angle += rotationSpeed * Mathf.Deg2Rad * Time.deltaTime;
    }
}
