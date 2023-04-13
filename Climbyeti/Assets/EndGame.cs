using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject walls;
    public GameObject finishCanvas;
    public Camera mc;
    public Camera endCam;

    private void Start()
    {
        mc.gameObject.SetActive(true);
        endCam.gameObject.SetActive(false);
        finishCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            Ending();
            Debug.Log("11");
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
        mc.transform.gameObject.SetActive(false);
        endCam.transform.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(10f);
        SceneLoader.LoadScene("StartScene");
    }
}