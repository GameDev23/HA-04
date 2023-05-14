using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioClip FlapSFX;
    public AudioClip EmptySFX;
    public AudioClip BackgroundMusic;
    public AudioClip Crash;
    public AudioClip CollectItem;
    public AudioClip Goal;
    public AudioSource SourceGlobal;
    public AudioSource sourceFlapSfx;
    public AudioSource sourceSfx;
    public AudioMixer Mixer;
    
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
