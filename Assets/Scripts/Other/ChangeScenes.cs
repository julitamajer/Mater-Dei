using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private DontDestroy[] dontDestroy;

    public delegate void Fade();
    public static event Fade OnFade;

    private void Start()
    {
        dontDestroy = FindObjectsOfType<DontDestroy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (var item in dontDestroy)
            {
                item.enabled = true;
            }

            OnFade?.Invoke();

            SceneManager.LoadScene(2);
        }
    }
}
