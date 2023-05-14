using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceGlobal.clip = AudioManager.Instance.BackgroundMusic;
        AudioManager.Instance.SourceGlobal.Play();
        AudioManager.Instance.SourceGlobal.volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
