using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float tiltSmooth = 5f;
    public float FlapForce = 1000f;
    public float Gravity = 7f;
    public float Fuel = 100f;
    public float FuelConsumption = 10f;

    
    
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private TextMeshProUGUI FuelText;
    [SerializeField] private Image FuelBar;


    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private bool didPlaySound = false;
    private Vector3 goalVector = Vector3.zero;

    private Gradient gradient = new Gradient();
    GradientColorKey[] gck = new GradientColorKey[2];
    GradientAlphaKey[] gak = new GradientAlphaKey[2];

    
    
    private void Awake()
    {
        // make plane fly to the right
        playerRigidBody.velocity = new Vector2(3f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        downRotation = Quaternion.Euler(0, 0, -75);
        forwardRotation = Quaternion.Euler(0, 0, 90);
        
        //this code is from ChatGPT
        GradientColorKey[] colorKeys = new GradientColorKey[3];
        colorKeys[0] = new GradientColorKey(Color.green, 1f);
        colorKeys[1] = new GradientColorKey(Color.yellow, 0.5f);
        colorKeys[2] = new GradientColorKey(Color.red, 0f);

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0] = new GradientAlphaKey(1f, 0f);
        alphaKeys[1] = new GradientAlphaKey(1f, 1f);

        gradient.SetKeys(colorKeys, alphaKeys);
        //ChatGPT
        
        //init FlapSFX
        AudioManager.Instance.sourceFlapSfx.clip = AudioManager.Instance.FlapSFX;
        AudioManager.Instance.sourceFlapSfx.volume = 0.2f;
    }

    //Physic goes in here
    private void FixedUpdate()
    {
        if (playerRigidBody.velocity.y >= -Gravity)
        {
            playerRigidBody.velocity += new Vector2(0f, -0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            DavidManager.switchToMainMenu();

        if (Manager.Instance.isGoal && goalVector == Vector3.zero)
        {
            goalVector = transform.position;
        }
        else if (Manager.Instance.isGoal)
        {
            transform.position = goalVector;
        }
        
        if (Manager.Instance.isAlive && !Manager.Instance.isGoal)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Fuel > 0)
            {

                playFlapSound();
                //tilt plane upwards
                transform.rotation = Quaternion.Lerp(transform.rotation, forwardRotation, tiltSmooth * Time.deltaTime * 2);
                //add upwards velocity upto 7
                if(playerRigidBody.velocity.y < 7)
                    playerRigidBody.AddForce(Vector2.up * FlapForce * Time.deltaTime, ForceMode2D.Force);

                if(Fuel > 0)
                    Fuel -= FuelConsumption * Time.deltaTime;
                if (Fuel < 0)
                    Fuel = 0;
            
            }
            else
            {
                AudioManager.Instance.sourceFlapSfx.Stop();
            }
            
            //tile plane downwards
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        
            //refresh fuel text and bar
            FuelText.text = Fuel > 0 ? (int) Fuel + "% Fuel" : "Empty";
            FuelBar.fillAmount = Fuel / 100;
        
            //adjust fuel color to gradient
            FuelBar.color = gradient.Evaluate(Fuel / 100);
            //play out of fuel sound if fuel is empty
            if(Fuel == 0 && !didPlaySound)
            {
                AudioManager.Instance.SourceGlobal.PlayOneShot(AudioManager.Instance.EmptySFX, 1f);
                didPlaySound = true;
            }
        }
        if (!Manager.Instance.isAlive)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)))
            {
                Debug.Log("Reset Scene");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                
            }
        }

    }
    
    private void playFlapSound()
    {
        if (!AudioManager.Instance.sourceFlapSfx.isPlaying)
            AudioManager.Instance.sourceFlapSfx.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(Manager.Instance.isAlive)
            AudioManager.Instance.SourceGlobal.PlayOneShot(AudioManager.Instance.Crash, 1f);
        Manager.Instance.isAlive = false;
        AudioManager.Instance.sourceFlapSfx.Stop();
        Debug.Log("Hit Something");
        if (collision.gameObject.name.Contains("rock"))
        {
            Debug.Log("Hit Rock");
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Manager.Instance.isAlive)
        {
            if (other.CompareTag("Fuel"))
            {
                Fuel = Fuel < 25 ? Fuel + 75 : 100;
            }
        }
    }
}

