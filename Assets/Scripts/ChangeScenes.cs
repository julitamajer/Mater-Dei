using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private DontDestroy[] dontDestroy;

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

            SceneManager.LoadScene(2);
        }
    }
}
