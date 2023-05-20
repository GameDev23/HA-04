using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SamwelManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool isGameOver = false;
    
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
        if (!Manager.Instance.isAlive && !isGameOver)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    public static void switchToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
