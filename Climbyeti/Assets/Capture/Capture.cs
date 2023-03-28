using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public enum Size
{
    POT64,
    POT128,
    POT256,
    POT512,
    POT1024,
}
public class Capture : MonoBehaviour
{
    public Camera cam;
    public RenderTexture rt;
    public Image bg;

    public Size size;

    private void Start()
    {
        cam = Camera.main;
        bg.color = Color.clear;
        SettingSize();
    }

    public void Create()
    {
        StartCoroutine(CaptureImage());
    }
    
    IEnumerator CaptureImage()
    {
        yield return null; // RenderTexture >> 변경사항이 적용되려면 한 프레임을 쉬어야 버그가 안생김

        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false, true);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);

        yield return null;

        var data = tex.EncodeToPNG();
        string name = "Thumbnail";
        string extuention = ".png";
        string path = Application.persistentDataPath + "/Thumbnail/";

        string filepath = @"C:\Users\user\AppData\LocalLow\DefaultCompany\Climbyeti\Thumbnail";
        
        //Debug.Log(path);

        if (!Directory.Exists(path)) 
            Directory.CreateDirectory(path);

        string[] FileNames = Directory.GetFiles(path, "*.png");
        string getName = Path.GetFileName(filepath);
        Debug.Log(getName);
        //Debug.Log(FileNames.Length);
        Debug.Log(FileNames);

        foreach (var nameofFile in FileNames)
        {
            Debug.Log(nameofFile.ToString());
        }

        
        
        for (int i = 0; i < FileNames.Length; i++)
        {
            if (FileNames[i] == path + name + ".png")
            {
                name = "Thumbnail" + FileNames.Length;
                Debug.Log("12312312");
            }
        }

        File.WriteAllBytes(path + name + extuention, data);

        yield return null;
    }

    void SettingSize()
    {
        switch (size)
        {
            case  Size.POT64:
                rt.width = 64;
                rt.height = 64;
                break;
            case  Size.POT128:
                rt.width = 128;
                rt.height = 128;
                break;
            case  Size.POT256:
                rt.width = 256;
                rt.height = 256;
                break;
            case  Size.POT512:
                rt.width = 512;
                rt.height = 512;
                break;
            case  Size.POT1024:
                rt.width = 1024;
                rt.height = 1024;
                break;
            default:
                break;
        }
    }
}
