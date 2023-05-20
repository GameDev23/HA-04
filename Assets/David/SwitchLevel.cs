using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("DavidLevel");
    }
    
    public void OnClickMarvin()
    {
        SceneManager.LoadScene("MarvinLevel");
    }
    
    public void OnClickSamwel()
    {
        Debug.LogError("Not implemented");
        //SceneManager.LoadScene("DavidLevel");
    }
}
