using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public List<DontDestroy> dontDestroyList;

    public delegate void Fade();
    public static event Fade OnFade;

    InputActionMap actionMap;
    GameObject player;

    private void Start()
    {
        Debug.Log("here");
        player = GameObject.FindWithTag("Player");
        actionMap = player.GetComponent<PlayerInput>().actions.FindActionMap("Player");
        dontDestroyList = new List<DontDestroy>(); // Initialize the list

        DontDestroy[] foundDontDestroy = FindObjectsOfType<DontDestroy>();

        foreach (var obj in foundDontDestroy)
        {
            if (obj != null)
            {
                dontDestroyList.Add(obj); // Add only if it's not null
            }
        }

        Debug.Log("Before removal: " + dontDestroyList.Count); // Check count before removal

        // Check if the list contains at least 5 elements before attempting to remove
        if (dontDestroyList.Count >= 5)
        {
            dontDestroyList.RemoveRange(0, 5); // Remove the first 5 elements
        }
        else
        {
            Debug.LogWarning("The list doesn't have enough elements to remove.");
        }

        Debug.Log("After removal: " + dontDestroyList.Count); // Check count after removal
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

            OnFade?.Invoke();
        }
    }
}
