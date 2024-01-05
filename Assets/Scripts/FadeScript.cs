using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    bool fadeIn;
    bool fadeOut;

    private void OnEnable()
    {
        ChangeScenes.OnFade += StartCorShow;
        SpawnPlayer.OutFade += StartCorHide;
    }

    private void StartCorShow()
    {
        StartCoroutine(ShowFade());
    }

    private void StartCorHide()
    {
        StartCoroutine(HideFade());
    }

    IEnumerator ShowFade()
    {
        fadeIn = true;

        while (fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;

                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        yield return null;
    }

    IEnumerator HideFade()
    {
        fadeOut = true;

        yield return new WaitForSeconds(1.8f);

        while (fadeOut && canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;

            yield return null;
        }

        fadeOut = false; 
    }


    private void OnDisable()
    {
        ChangeScenes.OnFade -= StartCorShow;
        SpawnPlayer.OutFade -= StartCorHide;
    }
}