using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGM : MonoBehaviour
{
    [ContextMenu("HTP")]
    public void ClickHtpButton()
    {
        
    }

    [ContextMenu("Start")]
    public void ClickStartButton()
    {
        //SceneManager.LoadScene("PlayScene");
        SceneLoader.LoadScene("PlayScene");
    }

    [ContextMenu("Exit")]
    public void ClickExitButton()
    {
        Application.Quit();
    }
}
