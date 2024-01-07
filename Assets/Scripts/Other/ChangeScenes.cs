using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private DontDestroy[] dontDestroy;

    public delegate void Fade();
    public static event Fade OnFade;

    [SerializeField] InputActionMap actionMap;

    private void Start()
    {
        dontDestroy = FindObjectsOfType<DontDestroy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            actionMap.Disable();

            foreach (var item in dontDestroy)
            {
                item.enabled = true;
            }

            OnFade?.Invoke();
        }
    }
}
