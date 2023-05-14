using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CapsuleCollider2D myCollider;

    private bool isHitboxActive = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        myCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.isSection2)
            transform.position += new Vector3(-6 * Time.deltaTime, 0 , 0);
        
        if (!Manager.Instance.isAlive && isHitboxActive)
        {
            myCollider.enabled = false;
            isHitboxActive = false;
        }
    }
}
