using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageChange : MonoBehaviour
{
    public Sprite[] ytImages;
    public Image yt;
    [Space] public RectTransform barTr;
    public Image barImage;

    private void Start()
    {
        StartCoroutine(ImageSwap());
        yt.transform.position = new Vector2(barTr.position.x - (barTr.rect.width / 2  * 7) + 350f, yt.transform.position.y);
    }

    private void Update()
    {
        ytMove();
    }

    private void ytMove()
    {
        yt.transform.position = new Vector2(barTr.transform.position.x - (barTr.rect.width / 2 * 7)
                                            + (barTr.rect.width / 2 * 7 * barImage.fillAmount) + 350f, yt.transform.position.y);
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
