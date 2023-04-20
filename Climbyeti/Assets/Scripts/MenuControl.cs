using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Head _Head;
    public Slider ySlider;
    public Slider zSlider;
    public GameObject menu;

    private void Start()
    {
        ySlider.value = -0.11f;
        zSlider.value = -0.06f;
    }

    private void Update()
    {
        MoveY();
        MoveZ();
    }

    private void MoveY()
    {
        _Head.headBodyOffset.y = ySlider.value;
    }

    private void MoveZ()
    {
        _Head.headBodyOffset.z = zSlider.value;
    }

    [ContextMenu("Menu_Close")]
    public void CloseMenu()
    {
        menu.SetActive(false);
    }
}
