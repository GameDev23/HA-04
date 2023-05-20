using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    bool isDisaabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDisaabled && !Manager.Instance.isAlive)
        {
            Collider2D MikusCock = gameObject.GetComponent<Collider2D>();
            MikusCock.enabled = false;
            isDisaabled = true;
        }
        
    }
}
