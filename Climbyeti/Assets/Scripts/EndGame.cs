using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject walls;
    public GameObject finishCanvas;
    public GameObject mc;
    public GameObject endCam;

    private void Start()
    {
        mc.SetActive(true);
        endCam.SetActive(false);
        finishCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            Ending();
        }
    }

    private void Ending()
    {
        walls.SetActive(false);
        finishCanvas.SetActive(true);
        StartCoroutine(EndCanvas());
    }

    IEnumerator EndCanvas()
    {
        finishCanvas.SetActive(true);
        mc.SetActive(false);
        endCam.SetActive(true);
        
        yield return new WaitForSeconds(10f);
        SceneLoader.LoadScene("StartScene");
    }
}