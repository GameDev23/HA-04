using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.isSection2)
            transform.position += new Vector3(-6 * Time.deltaTime, 0 , 0);
    }
}
