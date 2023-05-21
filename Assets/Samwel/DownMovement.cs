using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.down * 0.5f * Time.deltaTime;
        transform.Translate(movement);
    }
}
