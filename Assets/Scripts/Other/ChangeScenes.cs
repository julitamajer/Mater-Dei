using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeScenes : ScenesToChange
{
    List<DontDestroy> dontDestroyList;

    public delegate void Fade();
    public static event Fade OnFade;

    InputActionMap actionMap;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        actionMap = player.GetComponent<PlayerInput>().actions.FindActionMap("Player");
        dontDestroyList = new List<DontDestroy>();

        DontDestroy[] foundDontDestroy = FindObjectsOfType<DontDestroy>();

        foreach (var obj in foundDontDestroy)
        {
            if (obj != null)
            {
                dontDestroyList.Add(obj); 
            }
        }

        if (dontDestroyList.Count >= 5)
            dontDestroyList.RemoveRange(0, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            actionMap.Disable();

            foreach (var item in dontDestroyList)
            {
                item.enabled = true;
                item.DontDestroyObj();
            }

            ChangeScenes();
            OnFade?.Invoke();
        }
    }
}
