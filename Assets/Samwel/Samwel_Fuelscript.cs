using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samwel_Fuelscript: MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && Manager.Instance.isAlive)
        {
            AudioManager.Instance.sourceSfx.PlayOneShot(AudioManager.Instance.CollectItem, 2f);
            Destroy(gameObject);
        }
        
    }
}
