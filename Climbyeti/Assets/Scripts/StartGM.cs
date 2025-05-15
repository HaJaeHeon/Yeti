using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ActivePanel
{
    TitlePanel = 0,
    TutorialPanel = 1
}
public class StartGM : MonoBehaviour
{
    public ActivePanel activePanel = ActivePanel.TitlePanel;
    public GameObject[] panels;
    
    private void Start()
    {
     ChangePanel(ActivePanel.TitlePanel );   
    }

    [ContextMenu("Tutorial")]
    public void ClickTutorialButton()
    {
        ChangePanel(ActivePanel.TutorialPanel);
    }

    [ContextMenu("TutorialClose")]
    public void ClickTutorialCloseButton()
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
