using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class ImageChange : MonoBehaviour
{
    public Sprite[] ytImages;
    public Image yt;
    [Space] public RectTransform barTr;
    public Image barImage;

    private void Start()
    {
        StartCoroutine(ImageSwap());
    }

    IEnumerator ImageSwap()
    {
        yield return null;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        while (sceneName == "LoadingScene")
        {
            for (int i = 0; i < ytImages.Length; i++)
            {
                yt.sprite = ytImages[i];
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
