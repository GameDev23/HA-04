using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSection2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Manager.isSection2 = true;
        }
    }
}
