using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private DontDestroy[] dontDestroy;

    private void OnEnable()
    {
        UIBehaviour.OnEndGame += GoBackToMenu;
    }

    private void Start()
    {
        dontDestroy = FindObjectsOfType<DontDestroy>();
    }

    void GoBackToMenu()
    {
        foreach (var item in dontDestroy)
        {
            item.enabled = false;
        }

        StartCoroutine(WaitAndChange());
    }

    IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        UIBehaviour.OnEndGame -= GoBackToMenu;
    }
}