using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.isSection3)
            transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
    }
}
