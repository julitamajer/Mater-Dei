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

    private void GoBackToMenu()
    {
        StartCoroutine(WaitAndChange());
    }

    private IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        UIBehaviour.OnEndGame -= GoBackToMenu;
    }
}