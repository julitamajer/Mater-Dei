using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : ScenesToChange
{
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject lastScore;
    [SerializeField] TextMeshProUGUI lastScoreText;

    private bool hasPressedAnyKey = false;

    private void Update()
    {
        if (!hasPressedAnyKey && Input.anyKey)
        {
            hasPressedAnyKey = true; 
            StartCoroutine(BlackScreen(2.0f));
        }

        if (PlayerPrefs.GetInt("GamePlayed") == 1)
        {
            lastScore.SetActive(true);
            lastScoreText.SetText("HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString());
        }
    }

    private IEnumerator BlackScreen(float delay) 
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
        ChangeScenes();
    }
}
