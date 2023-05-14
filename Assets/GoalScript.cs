using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI progressText;

    private Vector2 playerPos;
    private Vector2 playerPosAtStart;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosAtStart = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate progress
        playerPos = player.transform.position;

        if (Manager.Instance.isGoal)
            progressText.text = "100%";
        else
        {
            progressText.text =
                "" + (int)(100 - (transform.position.x - playerPos.x) / (transform.position.x - playerPosAtStart.x) * 100) + "%";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.Instance.isGoal = true;
            StartCoroutine(Goal());
        }
    }

    IEnumerator Goal()
    {
        AudioManager.Instance.SourceGlobal.clip = AudioManager.Instance.Goal;
        AudioManager.Instance.SourceGlobal.Play();

        yield return new WaitForSeconds(3f);
        
        DavidManager.switchToMainMenu();
    }
}
