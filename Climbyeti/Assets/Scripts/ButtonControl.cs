using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class ButtonControl : MonoBehaviour
{
    private InputData _inputData;
    public GameObject htpPannel;
    public bool menuOpend;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        menuOpend = true;
    }

    private void Update()
    {
        //if(menuOpend || _inputData._leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButton))
        //    Invoke("OpenMenu", 0.5f);

        _inputData._leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButton);
        if(menuButton && menuOpend)
            Invoke("OpenMenu", 0.5f);

        Debug.Log(menuButton);
        Debug.Log(menuOpend);

        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        //    Debug.Log(triggerValue);
        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue))
        //    Debug.Log(primary2DAxisValue);
        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
        //    Debug.Log(primaryButtonValue);
        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        //    Debug.Log(gripValue);
        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButton))
        //    Debug.Log(menuButton);
    }

    public void CloseHTP()
    {
        htpPannel.SetActive(false);
    }

    public void OpenMenu()
    {
        if(menuOpend)
            menuOpend = false;
        else if (!menuOpend)
            menuOpend = true;
        Debug.Log("11");
    }
    

    //private InputDevice targetDevice;
    //private void Start()
    //{
    //    List<InputDevice> devices = new List<InputDevice>();
    //    InputDeviceCharacteristics rightControllerCharacteristics =
    //        InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
    //    InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
    //
    //    if (devices.Count > 0)
    //        targetDevice = devices[0];
    //    
    //}
    //
    //void Update()
    //{
    //    PrimeButton();
    //}
    //
    //private void PrimeButton()
    //{
    //    targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
    //    if (primaryButtonValue)
    //        Debug.Log("Pressing primary button");
    //
    //    targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
    //    if (triggerValue > 0.1F)
    //        Debug.Log("Trigger pressed " + triggerValue);
    //        
    //
    //    targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
    //    if (primary2DAxisValue != Vector2.zero)
    //        Debug.Log("Primary Touchpad " + primary2DAxisValue);
    //    
    //    targetDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue);
    //    if(menuButtonValue)
    //        Debug.Log("Pressing menu button");
    //    
    //    targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton);
    //    if(secondaryButton)
    //        Debug.Log("Pressing secondary button");
    //}
}
