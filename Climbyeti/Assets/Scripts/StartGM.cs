using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ActivePanel
{
    TitlePanel = 0,
    HTPanel = 1
}
public class StartGM : MonoBehaviour
{
    public ActivePanel pan = ActivePanel.TitlePanel;
    public GameObject[] panels;
    
    private void Start()
    {
     ChangePanel(ActivePanel.TitlePanel );   
    }

    [ContextMenu("HTP")]
    public void ClickHtpButton()
    {
        ChangePanel(ActivePanel.HTPanel);
    }

    [ContextMenu("HTP_Close")]
    public void ClickHTP_CloseButton()
    {
        ChangePanel(ActivePanel.TitlePanel);
    }

    private void ChangePanel(ActivePanel pan)
    {
        foreach (GameObject _panel in panels)
        {
            _panel.SetActive(false);
        }
        panels[(int)pan].SetActive(true);
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
#endif
        Application.Quit();
    }
}
