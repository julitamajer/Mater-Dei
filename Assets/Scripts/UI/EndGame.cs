using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private void OnEnable()
    {
        UIBehaviour.OnEndGame += GoBackToMenu;
    }

    void GoBackToMenu()
    {
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