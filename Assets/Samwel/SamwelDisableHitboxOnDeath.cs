using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamwelDisableHitboxOnDeath : MonoBehaviour
{
    private Collider2D myCollider;

    private bool isHitboxActive = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance != null)
        {
            if (!Manager.Instance.isAlive && isHitboxActive)
            {
                myCollider.enabled = false;
                isHitboxActive = false;
            }
        }
    }
}
