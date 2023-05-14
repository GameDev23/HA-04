using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    #region Global variables
    //Declare global variables here
    public bool isSection2 = false;
    public bool isSection3 = false;
    public bool isAlive = true;
    public bool isGoal = false;

    #endregion
    
    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
