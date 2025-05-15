using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class ButtonControl : MonoBehaviour
{
    private InputData _inputData;
    public GameObject tutorialPannel;
    public GameObject menuPannel;
    public bool coroutineRun = false;
    public Transform playerTr;
    public bool isMenuOpen;
    private void Start()
    {
        _inputData = GetComponent<InputData>();
        coroutineRun = false;
    }

    private void Update()
    {
        _inputData._leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButton);
        if (menuButton)
        {
            StartCoroutine(MenuCoroutine());
        }
        else if (!menuButton)
        {
            StopCoroutine(MenuCoroutine());
            coroutineRun = false;
        }

        if (menuPannel.activeSelf == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    [ContextMenu("TutorialClose")]
    public void CloseTutorial()
    {
        tutorialPannel.SetActive(false);
    }

    IEnumerator MenuCoroutine()
    {
        if (!coroutineRun)
        {
            coroutineRun = true;
            
            if(menuPannel.activeSelf)
                menuPannel.SetActive(false);
            else if (!menuPannel.activeSelf)
            {
                menuPannel.transform.position = playerTr.position +
                                                playerTr.forward * 10f;
                menuPannel.transform.rotation = playerTr.rotation;
                menuPannel.SetActive(true);
            }
        }

        yield return null;
    }

    [ContextMenu("OpenMenu")]
    private void OpenMenu()
    {
        if(menuPannel.activeSelf)
            menuPannel.SetActive(false);
        else
            menuPannel.SetActive(true);
    }

    [ContextMenu("TutorialOpen")]
    public void TutorialButton()
    {
        menuPannel.SetActive(false);
        tutorialPannel.transform.position = playerTr.position +
                                       playerTr.forward * 9.9f;
        tutorialPannel.transform.rotation = playerTr.rotation;
        Time.timeScale = 1;
        tutorialPannel.SetActive(true);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        SceneLoader.LoadScene("StartScene");
    }
}
