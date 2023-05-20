using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikuMovement : MonoBehaviour
{
    bool VerticalMikument = false;
    float elapsedTome = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VerticalMikument)
        {
            transform.position += Vector3.down * Time.deltaTime;
            elapsedTome += Time.deltaTime;
            
        }else if (!VerticalMikument)
        {
            transform.position += Vector3.up * Time.deltaTime;
            elapsedTome += Time.deltaTime;

        }
        if(elapsedTome >= 2f)
        {
            elapsedTome = 0;
            VerticalMikument = !VerticalMikument;
        }
        
    }
}
